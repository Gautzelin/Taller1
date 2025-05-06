namespace jcorreaTS1A.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void btnGuardar_Clicked(object sender, EventArgs e)
    {
        // Validaci�n de campos vac�os
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

        // Validar solo n�meros (Identificaci�n y Tel�fono)
        if (!txtIdentificacion.Text.All(char.IsDigit) || !txtTelefono.Text.All(char.IsDigit))
        {
            DisplayAlert("Error", "Identificaci�n y Tel�fono deben contener solo n�meros.", "OK");
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

        // Si todo es v�lido, guardar en archivo .txt
        string datos = $"Identificaci�n: {txtIdentificacion.Text}\n" +
                       $"Apellidos: {txtApellidos.Text}\n" +
                       $"Nombre: {txtNombre.Text}\n" +
                       $"Tel�fono: {txtTelefono.Text}\n" +
                       $"Correo: {txtCorreo.Text}\n";

        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string fileName = Path.Combine(documentsPath, "inscripcion.txt");
        File.WriteAllText(fileName, datos);

        DisplayAlert("�xito", $"Datos guardados en:\n{fileName}", "OK");

        // Opcional: limpiar campos
        txtIdentificacion.Text = "";
        txtApellidos.Text = "";
        txtNombre.Text = "";
        txtTelefono.Text = "";
        txtCorreo.Text = "";
        txtCorreoConfirmacion.Text = "";
    }
}