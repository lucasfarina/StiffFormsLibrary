using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StiffFormsLibrary
{
    public partial class PlaceHolderTextbox : TextBox
    {
        public PlaceHolderTextbox()
        {
            InitializeComponent();
            this.GotFocus += PlaceHolderTextbox_GotFocus;
            this.LostFocus += PlaceHolderTextbox_LostFocus;
        }

        private string placeHolder;
        private bool isPlaceHolding;
        public string TextPlaceHolder
        {
            get { return placeHolder; }
            set
            {
                placeHolder = value;
                if (!String.IsNullOrEmpty(TextPlaceHolder))
                {
                    AddPlaceHolder();
                }
                else
                {
                    RemovePlaceHolder();
                }
            }
        }

        void AddPlaceHolder()
        {
            base.Text = TextPlaceHolder;
            this.ForeColor = SystemColors.GrayText;
            isPlaceHolding = true;
        }

        void RemovePlaceHolder()
        {
            base.Text = "";
            this.ForeColor = SystemColors.WindowText;
            isPlaceHolding = false;
        }

        public override string Text { get => base.Text; set
            {
                if (String.IsNullOrEmpty(value))
                {
                    AddPlaceHolder();
                }
                else
                {
                    if (isPlaceHolding)
                        RemovePlaceHolder();
                    base.Text = value;
                }
            }
        }

        private void PlaceHolderTextbox_GotFocus(object sender, EventArgs e)
        {
            if(isPlaceHolding)
            {
                RemovePlaceHolder();
            }
        }

        private void PlaceHolderTextbox_LostFocus(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.Text) && !isPlaceHolding)
            {
                AddPlaceHolder();
            }
        }

        
    }
}
