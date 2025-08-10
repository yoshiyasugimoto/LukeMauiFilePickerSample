using LukeMauiFilePicker;

namespace LukeMauiFilePickerSample;

public partial class MainPage : ContentPage
{
	private readonly IFilePicker _filePicker;

	public MainPage(IFilePicker filePicker)
	{
		_filePicker = filePicker;
		InitializeComponent();
	}

	private async void OnUploadClicked(object? sender, EventArgs e)
	{
		try
		{
			var fileTypes = new Dictionary<DevicePlatform, IEnumerable<string>>
			{
				{ DevicePlatform.iOS, new[] { "public.item" } },
				{ DevicePlatform.Android, new[] { "*/*" } },
				{ DevicePlatform.MacCatalyst, new[] { "public.item" } },
				{ DevicePlatform.WinUI, new[] { "*" } }
			};
	
			var pickOptions = new PickOptions
			{
				FileTypes = new FilePickerFileType(fileTypes)
			};
	
			var file = await _filePicker.PickAsync(pickOptions);

			if (file != null)
			{
				UploadBtn.Text = $"Selected: {file.FileName}";
				SemanticScreenReader.Announce($"File selected: {file.FileName}");
				System.Diagnostics.Debug.WriteLine($"Picked fullpath: {file.FullPath}");
				System.Diagnostics.Debug.WriteLine($"Picked file: {file.FileName}");
			}
		}
		catch (Exception ex)
		{
			UploadBtn.Text = "Upload file";
			await DisplayAlert("Error", $"Failed to pick file: {ex.Message}", "OK");
		}
	}
}
