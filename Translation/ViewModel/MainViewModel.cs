using System.Net;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Translation.Service;

namespace Translation.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private GoogleTranslate _api;
        private DictService _dict;
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            _translationModel=new TranslationModel();
            TranslationCommand = new RelayCommand(ExecuteTranslation);
            _api = GoogleTranslate.Instance();
            _dict=DictService.Instance;
        }

        private TranslationModel _translationModel;

        public TranslationModel TranslationModel
        {
            get { return _translationModel; }
            set
            {
                _translationModel = value;
                this.RaisePropertyChanged(() => TranslationModel);
            }
        }

        private string _state;

        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                this.RaisePropertyChanged(() => State);
            }
        }

        private bool _isEnabled = true;

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                _isEnabled = value;
                this.RaisePropertyChanged(() => IsEnabled);
            }
        }


        public RelayCommand TranslationCommand { get; private set; }

        private void ExecuteTranslation()
        {
            IsEnabled = false;
            _dict.Load();
            Task task = Task.Factory.StartNew(() =>
            {
                try
                {
                    State = "Translating...";
                    TranslationModel.Result = _api.Translate(TranslationModel.Context,0);
                }
                catch (WebException ex)
                {
                    State = "ÇëÇó·þÎñÆ÷´íÎó£º" + ex.Message;
                }
                finally
                {
                    IsEnabled = true;
                }
            });
        }
    }
}