
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using Android.Text;

namespace MLearning.Droid
{
	public class PhraseView : RelativeLayout
	{
		TextView txtPhrase;
		TextView txtAuthor;
		ImageView imgComilla;
		ImageView imgBarra;
		Context context;

		LinearLayout linearBarra;
		LinearLayout linearTextContainer;
		RelativeLayout linearAll;

		int Altura =0;

		public PhraseView (Context context) :
		base (context)
		{
			this.context = context;
			Initialize ();
		}


		void Initialize ()
		{
			var textFormatdip = Android.Util.ComplexUnitType.Dip;
			this.LayoutParameters = new RelativeLayout.LayoutParams (-1,-2);
			this.SetGravity (GravityFlags.Center);

			linearAll = new RelativeLayout (context);
			linearTextContainer= new LinearLayout (context);
			linearBarra = new LinearLayout (context);

			txtAuthor = new TextView (context);
			txtPhrase = new TextView (context);
			imgBarra = new ImageView (context);
			imgComilla = new ImageView (context);

			linearAll.LayoutParameters = new RelativeLayout.LayoutParams (-1, -1);

			linearTextContainer.LayoutParameters = new LinearLayout.LayoutParams (Configuration.getWidth(500),-2);

			linearBarra.LayoutParameters = new LinearLayout.LayoutParams (Configuration.getWidth(30),-2);

			linearBarra.Orientation = Orientation.Vertical;
			linearTextContainer.Orientation = Orientation.Vertical;

			//linearAll.SetGravity (GravityFlags.Center);
			//linearBarra.SetGravity (GravityFlags.CenterHorizontal);
			linearTextContainer.SetGravity (GravityFlags.CenterVertical);

			//txtPhrase.SetTextSize (ComplexUnitType.Px, Configuration.getHeight (40));
			//txtAuthor.SetTextSize(ComplexUnitType.Px, Configuration.getHeight (30));

			txtPhrase.Typeface =  Typeface.CreateFromAsset(context.Assets, "fonts/ArcherMediumPro.otf");
			txtPhrase.SetTextSize (ComplexUnitType.Fraction, Configuration.getHeight(35));


			txtAuthor.SetTextSize(ComplexUnitType.Dip, 16.0f);
			txtAuthor.SetTextColor (Color.ParseColor("#b0afb5"));

			//linearBarra.AddView (imgComilla);
			//linearBarra.AddView (imgBarra);
			linearTextContainer.AddView (txtPhrase);
			linearTextContainer.AddView (txtAuthor);

			//linearAll.AddView (linearBarra);

			linearAll.AddView (imgComilla);
			linearAll.AddView (linearTextContainer);
			linearTextContainer.SetX (Configuration.getWidth (35));


			int padW = Configuration.getWidth(30);
			int padH = Configuration.getHeight (30);
			linearAll.SetPadding (padW,padH,padW,padH);
			//linearAll.SetBackgroundColor (Color.Blue);

			this.AddView (linearAll);

		}

		private String _phrase;
		public String Phrase{
			get{ return _phrase;}
			set{ _phrase = value;
				txtPhrase.TextFormatted = Html.FromHtml (_phrase);
				//txtPhrase.Text = _phrase;
			}

		}

		private String _author;
		public String Author{
			get{ return _author;}
			set{ _author = value;
				txtAuthor.Text = _author;
				//Altura = linearTextContainer.LayoutParameters.Height;
			}

		}

		private String _imagenComilla;
		public String ImagenComilla{
			get{ return _imagenComilla;}
			set{ _imagenComilla = value;

				imgComilla.SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset (_imagenComilla), Configuration.getWidth( 30), Configuration.getHeight (26), true));
			}
		}

		private String _imagenBarra;
		public String ImagenBarra{
			get{ return _imagenBarra;}
			set{ _imagenBarra = value;
				//	int valor = Altura;// - Configuration.getHeight (30);
				//	imgBarra.SetImageBitmap(Bitmap.CreateScaledBitmap (getBitmapFromAsset (_imagenBarra), Configuration.getWidth( 10),100, true));
			}
		}



		private String _colortext;
		public String ColorText{
			get{ return _colortext;}
			set{ _colortext = value;
				txtPhrase.SetTextColor(Color.ParseColor(_colortext));	}

		}


		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s =context.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}


	}
}

