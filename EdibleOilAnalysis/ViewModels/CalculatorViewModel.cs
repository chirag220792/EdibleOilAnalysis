using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace EdibleOilAnalysis.ViewModels
{
    public class CalculatorViewModel:BaseViewModel
    {
        private double normality;

        public double Normality
        {
            get { return normality; }
            set { normality = value; }
        }

        private double ffavolume;

        public double FFAVolume
        {
            get { return ffavolume; }
            set { ffavolume = value; }
        }

        private double blankffavolume;

        public double BlankFFAVolume
        {
            get { return blankffavolume; }
            set { blankffavolume = value; }
        }

        private double weightFFA;

        public double WeightFFA
        {
            get { return weightFFA; }
            set { weightFFA = value; }
        }

        private string ffa;

        public string FFA
        {
            get { return ffa; }
            set
            {
                ffa = value;
                OnPropertyChanged();
            }
        }

        private double proteinvolume;

        public double ProteinVolume
        {
            get { return proteinvolume; }
            set { proteinvolume = value; }
        }

        private double blankproteinvolume;

        public double BlankProteinVolume
        {
            get { return blankproteinvolume; }
            set { blankproteinvolume = value; }
        }

        private double weightprotein;

        public double WeightProtein
        {
            get { return weightprotein; }
            set { weightprotein = value; }
        }

        private string protein;

        public string Protein
        {
            get { return protein; }
            set
            {
                protein = value;
                OnPropertyChanged();
            }
        }

        private double oilvolume;

        public double OilVolume
        {
            get { return oilvolume; }
            set { oilvolume = value; }
        }

        private double blankoilvolume;

        public double BlankOilVolume
        {
            get { return blankoilvolume; }
            set
            {
                blankoilvolume = value;
                OilVolumeDifference = (oilvolume - blankoilvolume).ToString();
                OnPropertyChanged();
            }
            
        }

        private string oilvolumedifference;

        public string OilVolumeDifference
        {
            get { return oilvolumedifference; }
            set
            {
                oilvolumedifference = value;
                OnPropertyChanged();
            }
        }

        private double weightoil;

        public double WeightOil
        {
            get { return weightoil; }
            set { weightoil = value; }
        }

        private string oil;

        public string Oil
        {
            get { return oil; }
            set
            {
                oil = value;
                OnPropertyChanged();
            }
        }

        private bool ffaCheckBox = false;

        public bool FFACheckBox
        {
            get { return ffaCheckBox; }
            set
            {
                ffaCheckBox = value;
                OnPropertyChanged();
            }
        }

        private bool proteinCheckBox = false;

        public bool ProteinCheckBox
        {
            get { return proteinCheckBox; }
            set
            {
                proteinCheckBox = value;
                OnPropertyChanged();
            }
        }

        private bool oilCheckBox = false;

        public bool OilCheckBox
        {
            get { return oilCheckBox; }
            set
            {
                oilCheckBox = value;
                OnPropertyChanged();
            }
        }

        public ICommand CalculateCommand => new Command(Calculate);

        private void Calculate(object obj)
        {
            try
            {
                if (FFACheckBox)
                {
                    var resultFFA = (FFAVolume - BlankFFAVolume) * Normality * 28.2 / WeightFFA;
                    FFA = "Free Fatty Acids Result is :- " + resultFFA.ToString();
                }
                if (ProteinCheckBox)
                {
                    var resultprotein = (ProteinVolume - BlankProteinVolume) * Normality*6.25 *140/(WeightProtein*100);
                    Protein = "Protein Result is:- " + resultprotein.ToString() + " %";
                }
                if (OilCheckBox)
                {
                    var resultoil = (oilvolume - BlankOilVolume)*100 / WeightOil;
                    Oil = "Oil Result is:- " + resultoil.ToString();
                }

            }
            catch (Exception ex)
            {

            }
        }

        
        public CalculatorViewModel()
        {

        }
    }
}
