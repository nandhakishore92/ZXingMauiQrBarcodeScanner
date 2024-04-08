using ZXing.Net.Maui;

namespace ZXingMauiQrBarcodeScanner
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			barcodeReader.Options = new BarcodeReaderOptions
			{
				Formats = BarcodeFormats.All,
				AutoRotate = true,
				Multiple = false
			};
			barcodeReader.CameraLocation = CameraLocation.Front;
		}

		public void BarcodesDetected(object sender, BarcodeDetectionEventArgs e)
		{
			var first = e.Results?.FirstOrDefault();
			if (first is null)
				return;

			Dispatcher.DispatchAsync(async () =>
			{
				await DisplayAlert("Barcode Detected", first.Value, "OK");
			});
		}

	}
}
