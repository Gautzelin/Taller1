namespace jcorreaTS1A.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        // Validación de campos vacíos
        if (string.IsNullOrWhiteSpace(txtIdentificacion.Text) ||
            string.IsNullOrWhiteSpace(txtApellidos.Text) ||
            string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtTelefono.Text) ||
            string.IsNullOrWhiteSpace(txtCorreo.Text) ||
            string.IsNullOrWhiteSpace(txtCorreoConfirmacion.Text))
        {
            DisplayAlert("Error", "Por favor complete todos los campos.", "OK");
            return;
        }

        // Validar solo números (Identificación y Teléfono)
        if (!txtIdentificacion.Text.All(char.IsDigit) || !txtTelefono.Text.All(char.IsDigit))
        {
            DisplayAlert("Error", "Identificación y Teléfono deben contener solo números.", "OK");
            return;
        }

        // Validar solo letras (Nombre y Apellido)
        if (!txtNombre.Text.All(char.IsLetter) || !txtApellidos.Text.All(char.IsLetter))
        {
            DisplayAlert("Error", "Nombre y Apellidos deben contener solo letras.", "OK");
            return;
        }

        // Validar que los correos coincidan
        if (txtCorreo.Text != txtCorreoConfirmacion.Text)
        {
            DisplayAlert("Error", "Los correos no coinciden.", "OK");
            return;
        }

        // Si todo es válido, guardar en archivo .txt
        string datos = $"Identificación: {txtIdentificacion.Text}\n" +
                       $"Apellidos: {txtApellidos.Text}\n" +
                       $"Nombre: {txtNombre.Text}\n" +
                       $"Teléfono: {txtTelefono.Text}\n" +
                       $"Correo: {txtCorreo.Text}\n";

        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string fileName = Path.Combine(documentsPath, "inscripcion.txt");
        File.WriteAllText(fileName, datos);

        DisplayAlert("Éxito", $"Datos guardados en:\n{fileName}", "OK");

        // Opcional: limpiar campos
        txtIdentificacion.Text = "";
        txtApellidos.Text = "";
        txtNombre.Text = "";
        txtTelefono.Text = "";
        txtCorreo.Text = "";
        txtCorreoConfirmacion.Text = "";
    }
}