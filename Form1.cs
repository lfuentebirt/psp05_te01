using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;



namespace PSP05_TE_GestorPass
{
    public partial class Form1 : Form
    {
        // variables para los ficheros de las claves
        private string publicKeyFile = "public.xml";
        private string privateKeyFile = "private.xml";

        // variables para las rutas relativas de los ficheros
        private string rutaDirectorio = Path.Combine("..", "..", "bbdd");
        private string rutaClavePrivada = Path.Combine("..", "..", "privatekeys");
        private string rutaClavePublica = Path.Combine("..", "..", "publickeys");

        // datos de las contraseñas del usuario, se utiliza lo largo del programa para recoger los datos de los ficheros
        private DatosUsuario datosUsuario;
        public Form1()
        {
            InitializeComponent();

            // inicializamos los combos
            cbVisualizarDesc.Items.Add("No hay nada para mostrar");
            cbVisualizarDesc.SelectedIndex = 0;

            cbBorrarDesc.Items.Add("No hay nada para mostrar");
            cbBorrarDesc.SelectedIndex = 0;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /* Método para el registro del usuario
         *  Se inicializan los combos y los checkbox, así como el nombre de los ficheros y los datos del usuario
         *  Si el usuario esta registrado (tiene fichero) y tiene datos en el fichero, leemos los datos del fichero y los guardamos en datosUsuario mediante deserialziacion
         *  Si el usuario no esta registrado (no tiene fichero), creamos el fichero con el nombre e incluimos su nombre en datosUsuarios
         *  Si el usuario esta registrado, pero no tiene datos, no deserializamos, solo habilitamos los checkbox para gestionar las contraseñas
         */
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            String usuario = tbUsuario.Text;

            // inicializamos los combos y checkbox
            inicializarCombosYCheck();
            activarDesactivarCheckbox(false);

            // inicializamos la base del nombre de los ficheros
            publicKeyFile = "public.xml";
            privateKeyFile = "private.xml";

            // inicializamos los datos del usuario
            datosUsuario = null;

            // verificar que hay contenido en el nombre de usuario
            if (!String.IsNullOrEmpty(usuario) && comprobarUsuario(usuario))
            {
                // verificar si hay un fichero con su nombre
                String rutaFichero = Path.Combine(rutaDirectorio, tbUsuario.Text + ".txt");

                // construirmos el nombre de fichero
                publicKeyFile = tbUsuario.Text + "_" + publicKeyFile;
                privateKeyFile = tbUsuario.Text + "_" + privateKeyFile;

                if (File.Exists(rutaFichero)) // si existe - registrado 
                {
                    // activamos los checkbox para las opciones
                    activarDesactivarCheckbox(true);

                    // leemos el fichero
                    using (FileStream stream = new FileStream(rutaFichero, FileMode.Open))
                    {
                        if (stream.Length != 0) // si ya tiene contraseñas es que no es la primera vez que se accede
                        {
                            // leemos los datos del fichero y los guardamos en los datos de usuario mediante una deserializacion
                            BinaryFormatter formatter = new BinaryFormatter();
                            datosUsuario = (DatosUsuario)formatter.Deserialize(stream);

                            if(datosUsuario.datosContrasenas != null && datosUsuario.datosContrasenas.Count > 0)
                            {
                                // inicializamos los combos
                                cbVisualizarDesc.Items.Clear();
                                cbBorrarDesc.Items.Clear();

                                // cargamos los datos en los combos
                                foreach (DatosContrasena contra in datosUsuario.datosContrasenas)
                                {
                                    cbVisualizarDesc.Items.Add(contra.descripcion);
                                    cbVisualizarDesc.SelectedIndex = 0;

                                    cbBorrarDesc.Items.Add(contra.descripcion);
                                    cbBorrarDesc.SelectedIndex = 0;
                                }
                            }
                        }
                        else // primer acceso - recién registrado y sin contenido en el fichero, fichero si creado
                        {
                            // habilitar las opciones de contraseña para poder añadir contraseñas
                            cbVisualizarDesc.Enabled = true;
                            cbBorrarDesc.Enabled = true;
                            chRegistrar.Enabled = true;
                        } 
                    }
                }
                else // si no existe - Registro nuevo usuario
                {
                    // habilitamos el menu del registro de nuevo usuario
                    groupBox4.Enabled = true;

                    // mostramos un cuadro de dialogo
                    String mensaje = "El usuario no existe, debes crearlo";
                    DialogResult mensajenNoExiste = MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // desactivamos las opciones de los checkbox
                    activarDesactivarCheckbox(false);

                    // inicializamos los valores del combobox
                    inicializarCombosYCheck();
                }
            }
        }
        /*
         * Método para inicializar los valores de los checkbox y combobox
         *  Inicializamos los combos con el valor por defecto
         *  Deshabilitamos los checkbox
         *  Inicializamos las labels
         */
        private void inicializarCombosYCheck()
        {
            // inicializar comboboxs
            cbVisualizarDesc.Items.Clear();
            cbVisualizarDesc.Items.Add("No hay nada para mostrar");
            cbVisualizarDesc.SelectedIndex = 0;

            cbBorrarDesc.Items.Clear();
            cbBorrarDesc.Items.Add("No hay nada para mostrar");
            cbBorrarDesc.SelectedIndex = 0;

            // desactivar los checkbox
            chRegistrar.Checked = false;
            chBorrar.Checked = false;
            chVisualizar.Checked = false;

            // inicializamos los textbox
            tbRegistrarDesc.Clear();
            tbRegistrarContrasena.Clear();

            // inicializamos las labels
            lbUbicacion.Text = string.Empty;
            tbContrasenaDescif.Text = string.Empty;
        }
        /*
         * Método para activar y desactivar los checkbox para gestionar las contraseñas y deshabilitar el registro de usuarios
         *  Parametro de entrada es un bool que indica si se activan o no
         */
        private void activarDesactivarCheckbox(bool activado)
        {
            // habilitamos las opciones de la contraseña
            chRegistrar.Enabled = activado;
            chBorrar.Enabled = activado;
            chVisualizar.Enabled = activado;

            // lo contrario para el registro de usuarios
            groupBox4.Enabled = !activado;
        }
        /*
         * Método para comprobar si el usuario cumple con los criterios necesarios
         *  Utilizamos Regex y le indicamos el patron a cumplir
         */
        private bool comprobarUsuario(string usuario)
        {
            if(usuario.Length >= 4 && usuario.Length <= 10) // longitud 8 - 10
            {
                if(usuario.Equals(usuario.ToLower())) // tiene que ser en minusculas
                {
                    // patron solo letras
                    string patron = @"^[a-zA-Z]+$";
                    
                    if(Regex.IsMatch(usuario, patron)) // comprobamos
                    {
                        return true;
                    }
                }
            }
            // mostramos un cuadro de dialogo
            String mensaje = "El formato del nombre de usuario es incorrecto";
            DialogResult mensajenNoExiste = MessageBox.Show(mensaje, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return false;
        }

        private void rbRegistroSi_CheckedChanged(object sender, EventArgs e)
        {
        }

        /* Método para calcular las claves
        *   Como parametros de entrada tenemos el final de la cadena de las claves publica y privada
        *   Utilizamos RSA para generar las claves
        *   Creamos el fichero
        */
        private void generarClaves(string ficheroPublico, string ficheroPrivado)
        {
            using (var rsa = new RSACryptoServiceProvider(2048)) // cifrado asimetrico RSA
            {
                rsa.PersistKeyInCsp = false;
                
                string publicKey = rsa.ToXmlString(false); // clave publica

                // generamos la ruta del fichero de clave publica
                string rutaPubl = Path.Combine(rutaClavePublica, ficheroPublico);
                File.WriteAllText(rutaPubl, publicKey); // generamos la clave publica


                string privateKey = rsa.ToXmlString(true); // clave privada

                // generamos la ruta del fichero de clave privada
                string rutaPriv = Path.Combine(rutaClavePrivada, ficheroPrivado);
                File.WriteAllText(rutaPriv, privateKey); // generamos la clave privada
            }
        }
        /*
         * Método para registrar un nuevo usuario
         *  Validamos el formato del email mediante Regex
         *  Generemos el fichero del usuario
         *  Generamos las claves 
         *  Enviamos el correo con la clave privada
         *  Habilitamos los controles de la gestion de contraseñas
         */
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(rbRegistroSi.Checked)
            {
                // validar email
                if (!String.IsNullOrEmpty(tbEmail.Text))
                {
                    String correo = tbEmail.Text;

                    // regex con patron
                    string patron = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

                    if (Regex.IsMatch(correo, patron)) // validamos
                    {
                        // generamos la ruta del fichero del usuario
                        String rutaFichero = Path.Combine(rutaDirectorio, tbUsuario.Text + ".txt");

                        // geberamos el fichero
                        FileStream stream = new FileStream(rutaFichero, FileMode.Create);

                        // generamos la clave publica y privada
                        generarClaves(publicKeyFile, privateKeyFile);

                        // envio de la clave privada por email
                        envioEmail();

                        // habilitar las opciones de contraseña para poder añadir contraseñas
                        chVisualizar.Enabled = true;
                        chBorrar.Enabled = true;
                        chRegistrar.Enabled = true;

                        // cuando se completa, se muestra el mensaje
                        DialogResult mensajenNoExiste = MessageBox.Show("Registro Creado, puedes encontrar tu fichero en: " + Path.Combine(rutaClavePrivada, privateKeyFile), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // deshabilitamos el registro de usuarios
                        groupBox4.Enabled = false;
                    }
                    else // retroalimentacion -  en caso de formato de correo incorrecto
                    {
                        MessageBox.Show("Correo incorrecto", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else // retroalimentacion - en caso de que no haya datos de correo
                {
                    MessageBox.Show("No hay datos de correo", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else  // retroalimentacion - en caso de pulsar el boton y no pulsar el radiobutton NO
            {
                MessageBox.Show("Ha seleccionado SI, debe seleccionar NO", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /*
         * Método para el envio del email con SMTP la clave privada
         *  Formamos el mensaje, añadimos el adjunto y lo enviamos
         */
        private void envioEmail()
        {
            // formamos los datos del correo
            string asunto = "clave privada";
            string cuerpo = "Clave de acceso a contraseñas en el gestor de password.";

            MailAddress origen = new MailAddress("lfpsp04@gmail.com", "From BirtGestorPass");
            MailAddress destino = new MailAddress(tbEmail.Text, "To Usuario");

            try
            {
                SmtpClient smtp = new SmtpClient // utilizamos SMTP
                {
                    Host = "smtp.gmail.com",
                    Port = 587, // por defecto para TLS 
                    Credentials = new NetworkCredential(origen.Address, "vsmm kcsz jpst lwng"), // mi contraseña de aplicacion
                    EnableSsl = true
                };

                MailMessage mensaje = new MailMessage(origen, destino);
                mensaje.Subject = asunto; 
                mensaje.Body = cuerpo;

                // añadimos el fichero adjunto
                string rutaFichero = Path.Combine(rutaClavePrivada, privateKeyFile);
                Attachment archivoAdjunto = new Attachment(rutaFichero);
                mensaje.Attachments.Add(archivoAdjunto);

                // enviamos
                smtp.Send(mensaje);
            }
            catch (Exception ex) // gestionamos las excepciones
            {
                MessageBox.Show("Error:  " + ex.Message, "Envío email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
         *  Método para habilitar y deshabilitar el grupo de la opcion de Visualizacion
         */
        private void chVisualizar_CheckedChanged(object sender, EventArgs e)
        {
            if (chVisualizar.Checked)
            {
                groupBox1.Enabled = true;
                cbVisualizarDesc.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
                cbVisualizarDesc.Enabled = false;
            }

        }
        /*
         *  Método para habilitar y deshabilitar el grupo de la opcion de Registro
         */
        private void chRegistrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chRegistrar.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }
        /*
         *  Método para habilitar y deshabilitar el grupo de la opcion de Borrado
         */
        private void chBorrar_CheckedChanged(object sender, EventArgs e)
        {
            if (chBorrar.Checked)
            {
                groupBox3.Enabled = true;
                cbBorrarDesc.Enabled = true;
            }
            else
            {
                groupBox3.Enabled = false;
                cbBorrarDesc.Enabled = false;
            }
        }
        /*
         *  Método para guardar los datos de las contraseñas del usuario en su fichero
         *    Controlamos que los datos de usuario esten inicializados
         *    Verificamos que no exista una contraseña con la misma descripcion
         *    Retroalimentacion
         *    Añadimos los datos a la variable general
         */
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // textBox1.UseSystemPasswordChar = true; para que no se vea la contraséña

            bool descripcionPrevia = false;

            if (datosUsuario != null) // para controlar que este inicializado
            {
                // verificamos que no haya una descripcion igual a la que se incluye
                foreach (DatosContrasena contra in datosUsuario.datosContrasenas) 
                {
                    if (contra.descripcion.Equals(tbRegistrarDesc.Text))
                    {
                        descripcionPrevia = true;
                    }
                }
            }

            if (!descripcionPrevia) // si no hay una descripcion igual registrada
            {
                if (datosUsuario == null) // si no estan inicializados los datos, los inicializamos
                {
                    datosUsuario = new DatosUsuario();
                    datosUsuario.datosContrasenas = new List<DatosContrasena>();

                }

                cbBorrarDesc.Items.Clear();
                cbVisualizarDesc.Items.Clear();
            }
            else
            { // retroaliimentación - indicamos si ya existe una contraseña con esa descripcion

                MessageBox.Show("Ya existe una contraseña con esa descripcion", "Requisitos de la Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // controlar que haya contenido y que no exista una descripcion previa igual
            if (!String.IsNullOrEmpty(tbRegistrarContrasena.Text) && !String.IsNullOrEmpty(tbRegistrarDesc.Text) && !descripcionPrevia) { 

                // verificar que la contraseña cumple con el patron
                string patron = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#&()–\[{}\]:'?/*~$^+=<>]).{8,10}$";

                // utilizamos Regex
                Regex regex = new Regex(patron);

                if (regex.IsMatch(tbRegistrarContrasena.Text))
                {
                    // guardamos los datos de la contraseña en datosUsuario
                    DatosContrasena datoContra = new DatosContrasena();
                    datoContra.descripcion = tbRegistrarDesc.Text;
                    datoContra.contrasenaCifrada = cifrar(tbRegistrarContrasena.Text);
                    datosUsuario.datosContrasenas.Add(datoContra);

                    // añadimos a los combos
                    cbBorrarDesc.Items.Add(datoContra.descripcion);
                    cbVisualizarDesc.Items.Add(datoContra.descripcion);

                    // indicamos el indice seleccionado
                    cbBorrarDesc.SelectedIndex = 0;
                    cbVisualizarDesc.SelectedIndex = 0;
                }
                else // retroalimentación - si el formato de la contraseña no es correcto
                {
                    mensajeFormatoContrasena();
                }
            }
            else // retroalimentación - si el formato de la contraseña no es correcto
            {
                mensajeFormatoContrasena();
            }
        }
        /*
         * Método para mostrar el mensaje para indicar que el formato de la contraseña no es correcta
         */
        private void mensajeFormatoContrasena()
        {
            string mensaje = "Verifica si la contraseña es correcta:" + Environment.NewLine +
             "8-10 dígitos.\n" + Environment.NewLine +
             "Al menos 1 mayúscula, 1 minúscula, 1 número.\n" + Environment.NewLine +
             "1 carácter entre estos: !@#&()–[{}:',?/*~$^+=<>";

            MessageBox.Show(mensaje, "Requisitos de la Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /*
         * Método para cifrar la contraseña con la clave publica con RSA
         */
        private byte[] cifrar(string contrasena)
        {
            byte[] cifrado;

            using (var rsa = new RSACryptoServiceProvider(2048)) // RSA cifrado asimetrico
            {
                rsa.PersistKeyInCsp = false;

                // utilizamos la clave publica
                string publicKey = File.ReadAllText(Path.Combine(rutaClavePublica, publicKeyFile));

                rsa.FromXmlString(publicKey);

                // pasamos la contraseña a byte[]
                byte[] contrasenaByte = Encoding.UTF8.GetBytes(contrasena);

                // encriptamos
                cifrado = rsa.Encrypt(contrasenaByte, true);
            }

            return cifrado;
        }
        /*
         * Método para obtener la clave privada para descifrar la contraseña
         *  Se abre el explorador de ficheros de Windows y se selecciona la clave privada
         *  Se llama al emtodo descifrar y se obtiene la contraseña descifrada
         */
        private void btnFicheroClave_Click(object sender, EventArgs e)
        {
            try
            {
                if (datosUsuario != null && datosUsuario.datosContrasenas != null)
                {
                    // abrimos el explorador de Windows para obtener el fichero de la clave privada
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    String nombreFichero;

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        nombreFichero = openFileDialog1.FileName;

                        // indicamos la ruta seleccionada
                        lbUbicacion.Text = nombreFichero;
                        lbUbicacion.Visible = true;

                        // desciframos
                        byte[] desencriptado = descifrar(nombreFichero);

                        // indicamos la contraseña descifrada
                        tbContrasenaDescif.Text = Encoding.UTF8.GetString(desencriptado);
                    }
                }
                else // retroalimentacion - si no hay datos del usuario
                {
                    MessageBox.Show("No hay datos", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex) // controlamos las excepciones
            {
                MessageBox.Show("Error:  " + ex.Message, "Descifrar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*
         * Método para desencriptar la contraseña
         *  RSA para el descifrado asimetrico con el fichero que se pasa como parametro en el metodo
         */
        private byte[] descifrar(string nombreFichero)
        {
            byte[] desencriptado;

            using (var rsa = new RSACryptoServiceProvider(2048)) // utilizamos RSA  para descifrar
            {
                FileStream stream = File.OpenRead(nombreFichero); // abrimos el fichero de la clave privada
                
                rsa.PersistKeyInCsp = false;

                string privateKey = File.ReadAllText(nombreFichero);

                // seleccionamos el dato contraséña que coincida con la descripcion seleccionada
                DatosContrasena datos = datosUsuario.datosContrasenas[cbVisualizarDesc.SelectedIndex];
                rsa.FromXmlString(privateKey);
                
                // desencriptamos
                desencriptado = rsa.Decrypt(datos.contrasenaCifrada, true);
            }
            return (desencriptado);
        }
        /*
         * Método para borrar la contraseña seleccionada
         *  Controlar que haya elementos y que no tengamos el elemento de inicializacion
         *  Eliminamos el elemento de datosUsuario
         *  Actualizamos los combos
         */
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // controlamos las condiciones necesarias
            if (cbBorrarDesc.Items.Count > 0 && datosUsuario != null && datosUsuario.datosContrasenas != null && datosUsuario.datosContrasenas.Count() > 0) 
            {
                // identificar la contraseña a borrar
                DatosContrasena datosBorrar = datosUsuario.datosContrasenas[cbBorrarDesc.SelectedIndex];

                // actualizar combos
                if(datosUsuario.datosContrasenas.Count - 1 > 0) // si al quitarle el elemento tiene más, lo quitamos
                {
                    cbBorrarDesc.Items.Remove(datosBorrar.descripcion);
                    cbBorrarDesc.SelectedIndex = 0;

                    cbVisualizarDesc.Items.Remove(datosBorrar.descripcion);
                    cbVisualizarDesc.SelectedIndex = 0;
                }
                else // si se queda a cero, indicamos la cadena 
                {
                    cbVisualizarDesc.Items.Clear();
                    cbVisualizarDesc.Items.Add("No hay nada para mostrar");
                    cbVisualizarDesc.SelectedIndex = 0;

                    cbBorrarDesc.Items.Clear();
                    cbBorrarDesc.Items.Add("No hay nada para mostrar");
                    cbBorrarDesc.SelectedIndex = 0;

                    tbContrasenaDescif.Text = String.Empty;
                    lbUbicacion.Text = String.Empty;
                    tbRegistrarContrasena.Text = String.Empty;
                    tbRegistrarDesc.Text = String.Empty;
                }

                // borramos del objeto de los datosUsuario
                datosUsuario.datosContrasenas.Remove(datosBorrar);
            }
            else // retroalimentacion - no hay datos
            {
                MessageBox.Show("No hay datos a borrar", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        /*
         * Método para guardar las contraseñas de las que se dispone en el momento
         *  Tiene que haber datos de usuario y que el usuario este registrado
         *  Grabamos los datos de usuario en el fichero del usuario
         *  Cerramos el programa
         */
        private void btnGuardarCerrar_Click(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(tbUsuario.Text) && datosUsuario != null) // controlamos
            {
                datosUsuario.nombre = tbUsuario.Text;

                String rutaFichero = Path.Combine(rutaDirectorio, tbUsuario.Text + ".txt");

                if(File.Exists(rutaFichero)) // verificamos que tenga ya su fichero
                {
                    try
                    {
                        // grabar datos en el fichero
                        using (FileStream stream = new FileStream(rutaFichero, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            BinaryFormatter formatter = new BinaryFormatter();
                            formatter.Serialize(stream, datosUsuario); // serializamos
                        }

                    }
                    catch (Exception ex) // controlamos si hay excepciones
                    {
                        MessageBox.Show("Error:  " + ex.Message, "Envío email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // cerrar el programa
            Environment.Exit(0);
        }
    }
    [Serializable]
    /*
     *  Clase para guardar los datos del usuario y las contraseñas
     *      Se utilizará para guardar los datos leidos del fichero y para grabarlos en el fichero
     *      Tenemos un objeto de DatosContrasena (lista) para guardar cada contraseña
     */
    public class DatosUsuario  
    {
        public String nombre;
        public List<DatosContrasena> datosContrasenas;

        public override string ToString()
        {
            return "Nombre:" + nombre + ", Contrasenas: {" + datosContrasenas.ToString() + "}";
        }

    }
    [Serializable]
    /*
     * Clase para guardar los datos de la contraseña que se registre
     *  Cada usuario podrá tener tantas contraseñas como quiera pero su descripcion no podra coincidir
     */
    public class DatosContrasena
    {
        public string descripcion;
        public byte[] contrasenaCifrada;
        public override string ToString()
        {
            return "Descripcion: " + descripcion + ", Contrasena cifrada: " + contrasenaCifrada;
        }
    }
}

     