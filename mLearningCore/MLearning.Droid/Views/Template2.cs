
using System;
using System.Collections.Generic;
using System.Linq;
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
using Android.Widget;

namespace MLearning.Droid
{
	public class Template2 : RelativeLayout
	{
		RelativeLayout mainLayout;
		LinearLayout contenLayout;

		TextView titleHeader;
		TextView content;

		int widthInDp;
		int heightInDp;

	

		Context context;

		public LinearLayout textContent;

		public Template2 (Context context) :
		base (context)
		{
			this.context = context;
			Initialize ();
		}

		void Initialize ()
		{
			var metrics = Resources.DisplayMetrics;
			widthInDp = ((int)metrics.WidthPixels);
			heightInDp = ((int)metrics.HeightPixels);
			Configuration.setWidthPixel (widthInDp);
			Configuration.setHeigthPixel (heightInDp);

			ini ();
			this.AddView (mainLayout);

		}


		public Bitmap getBitmapFromAsset( String filePath) {
			System.IO.Stream s = context.Assets.Open (filePath);
			Bitmap bitmap = BitmapFactory.DecodeStream (s);

			return bitmap;
		}

		private string _colorBackgroundTitle;
		public string ColorBackgroundTitle{
			get{return _colorBackgroundTitle; }	
			set{
				_colorBackgroundTitle = value;
				titleHeader.SetBackgroundColor (Color.ParseColor (_colorBackgroundTitle));
			}
		}

		private string _colorTitle;
		public string ColorTitle{
			get{ return _colorTitle;}
			set{ _colorTitle = value;
				titleHeader.SetTextColor (Color.ParseColor (_colorTitle));
			}
		}

		private string _colorBackgroundDescription;
		public string ColorBackgroundDescription{
			get{return _colorBackgroundDescription; }	
			set{
				_colorBackgroundDescription = value;
				content.SetBackgroundColor (Color.ParseColor (_colorBackgroundDescription));
			}
		}

		private string _colorDescription;
		public string ColorDescription{
			get{ return _colorDescription;}
			set{ _colorDescription = value;
				content.SetTextColor (Color.ParseColor (_colorDescription));
			}
		}

		private string _colorBackgroundTemplate;
		public string ColorBackgroundTemplate{
			get{return _colorBackgroundTemplate; }	
			set{
				_colorBackgroundTemplate = value;
				mainLayout.SetBackgroundColor (Color.ParseColor (_colorBackgroundTemplate));
			}
		}

		private string _color;
		public string ColorTexto{
			get{return _color; }
			set{_color = value;
				titleHeader.SetTextColor(Color.ParseColor(_color));
			}

		}
		public void ini(){

			var textFormat = Android.Util.ComplexUnitType.Px;
			var textFormatdip = Android.Util.ComplexUnitType.Dip;



			mainLayout = new RelativeLayout (context);
			mainLayout.LayoutParameters = new RelativeLayout.LayoutParams (-1,-1);

			contenLayout = new LinearLayout (context);
			contenLayout.LayoutParameters = new LinearLayout.LayoutParams (-2, -2);
			contenLayout.Orientation = Orientation.Vertical;

			titleHeader = new TextView (context);
			content = new TextView (context);

			titleHeader.Typeface =  Typeface.CreateFromAsset(context.Assets, "fonts/ArcherMediumPro.otf");
			content.Typeface =  Typeface.CreateFromAsset(context.Assets, "fonts/ArcherMediumPro.otf");

			titleHeader.SetTextSize (ComplexUnitType.Fraction, Configuration.getHeight(38));
			content.SetTextSize (ComplexUnitType.Fraction, Configuration.getHeight(32));

			textContent = new LinearLayout (context);
			textContent.LayoutParameters = new LinearLayout.LayoutParams (-2, -2);

			contenLayout.AddView (titleHeader);
			contenLayout.AddView(content);

			int padW = Configuration.getWidth(30);
			int padH = Configuration.getHeight (5);

			mainLayout.SetPadding (padW,padH,padW,padH);
			mainLayout.AddView(contenLayout);
			//mainLayout.SetBackgroundColor (Color.Cyan);

		}

		private string _title;
		public string Title{
			get{return _title; }
			set{_title = value;
				titleHeader.TextFormatted = Html.FromHtml(_title);
			}

		}



		private string _content;
		public string Contenido{
			get{return _content; }
			set{_content = value;
				content.TextFormatted = Html.FromHtml (_content);
	                
				    
				ViewTreeObserver vto = contenLayout.ViewTreeObserver;
				int H = 0;
				vto.GlobalLayout += (sender, args) =>
				{     
					H = contenLayout.Height;
					Console.WriteLine ("TAM::::" + H );
					contenLayout.LayoutParameters.Height = H-Configuration.getHeight(40);

				};  
				//contenLayout.LayoutParameters = new LinearLayout.LayoutParams (-2, H);

			}


		}
	}
}


