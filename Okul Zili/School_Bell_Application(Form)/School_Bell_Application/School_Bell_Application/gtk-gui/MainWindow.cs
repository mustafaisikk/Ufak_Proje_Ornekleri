using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;

public partial class MainWindow
{
	private global::Gtk.Fixed fixed1;

	private global::Gtk.Entry entry1;

	private global::Gtk.Button button1;

	private global::Gtk.ScrolledWindow GtkScrolledWindow;

	private global::Gtk.TextView textview1;

	private global::Gtk.ScrolledWindow GtkScrolledWindow1;

	private global::Gtk.TextView textview2;

	private global::Gtk.Entry entry2;

	protected virtual void Build()
	{
		global::Stetic.Gui.Initialize(this);
		// Widget MainWindow
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString("MainWindow");
		this.WindowPosition = ((global::Gtk.WindowPosition)(4));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.fixed1 = new global::Gtk.Fixed();
		this.fixed1.Name = "fixed1";
		this.fixed1.HasWindow = false;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.entry1 = new global::Gtk.Entry();
		this.entry1.WidthRequest = 70;
		this.entry1.CanFocus = true;
		this.entry1.Name = "entry1";
		this.entry1.IsEditable = true;
		this.entry1.InvisibleChar = '●';
		this.fixed1.Add(this.entry1);
		global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.entry1]));
		w1.X = 10;
		w1.Y = 10;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.button1 = new global::Gtk.Button();
		this.button1.HeightRequest = 0;
		this.button1.CanFocus = true;
		this.button1.Name = "button1";
		this.button1.UseUnderline = true;
		this.button1.Label = global::Mono.Unix.Catalog.GetString("EKLE");
		this.fixed1.Add(this.button1);
		global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button1]));
		w2.X = 90;
		w2.Y = 9;
        button1.Clicked += new EventHandler(Button_Clicked);
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow.WidthRequest = 125;
		this.GtkScrolledWindow.HeightRequest = 100;
		this.GtkScrolledWindow.Name = "GtkScrolledWindow";
		this.GtkScrolledWindow.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow.Gtk.Container+ContainerChild
		this.textview1 = new global::Gtk.TextView();
		this.textview1.CanFocus = true;
		this.textview1.Name = "textview1";
		this.textview1.Editable = false;
		this.textview1.Justification = ((global::Gtk.Justification)(2));
		this.GtkScrolledWindow.Add(this.textview1);
		this.fixed1.Add(this.GtkScrolledWindow);
		global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.GtkScrolledWindow]));
		w4.X = 10;
		w4.Y = 60;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.GtkScrolledWindow1 = new global::Gtk.ScrolledWindow();
		this.GtkScrolledWindow1.WidthRequest = 202;
		this.GtkScrolledWindow1.HeightRequest = 110;
		this.GtkScrolledWindow1.Name = "GtkScrolledWindow1";
		this.GtkScrolledWindow1.ShadowType = ((global::Gtk.ShadowType)(1));
		// Container child GtkScrolledWindow1.Gtk.Container+ContainerChild
		this.textview2 = new global::Gtk.TextView();
		this.textview2.CanFocus = true;
		this.textview2.Name = "textview2";
		this.textview2.Editable = false;
		this.textview2.Justification = ((global::Gtk.Justification)(2));
		this.GtkScrolledWindow1.Add(this.textview2);
		this.fixed1.Add(this.GtkScrolledWindow1);
		global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.GtkScrolledWindow1]));
		w6.X = 160;
		w6.Y = 50;
		// Container child fixed1.Gtk.Fixed+FixedChild
		this.entry2 = new global::Gtk.Entry();
		this.entry2.WidthRequest = 75;
		this.entry2.Sensitive = false;
		this.entry2.Name = "entry2";
		this.entry2.Text = global::Mono.Unix.Catalog.GetString("");
		this.entry2.IsEditable = false;
        entry2.InvisibleChar = '●';
        fixed1.Add(this.entry2);
		global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.entry2]));
		w7.X = 220;
		w7.Y = 10;
		this.Add(this.fixed1);
		if ((this.Child != null))
		{
			this.Child.ShowAll();
		}
		this.DefaultWidth = 379;
		this.DefaultHeight = 174;
		this.Show();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler(this.OnDeleteEvent);
        GLib.Timeout.Add(100, new GLib.TimeoutHandler(Update));
    }

    List<Bell_Prop> Bells = new List<Bell_Prop>();
    List<string> Outputs = new List<string>();
    public int temp1;

    public void Bell_Out()
    {
        foreach (Bell_Prop var in Bells)
        {
            if (DateTime.Now.Hour == var.Hour && DateTime.Now.Minute == var.Minute)
            {
                string temp= "" + var.Hour + " " + var.Minute + " Zili Çaldı...";
                if (Outputs.Contains(temp) != true)
                {
                    Outputs.Add(temp);
                }
                return;
            }
        }
        return ;
    }
    public bool Update()
    {
        entry2.Text = DateTime.Now.ToString("HH:mm:ss");
        Bell_Out();
        Output_Lists();
        return true;
    }

    public void Output_Lists()
    {
        if (Outputs.Count != temp1)
        {
            textview2.Buffer.Text = "";
            var iter = this.textview2.Buffer.GetIterAtLine(0);
            foreach (string var in Outputs)
            {
                textview2.Buffer.InsertWithTags(ref iter, var+ "\n");
            }
            temp1 = Outputs.Count();
        }
    }

    public class Bell_Prop
    {
        public int Hour;
        public int Minute;

        public Bell_Prop(int a, int b)
        {
            this.Hour = a;
            this.Minute = b;
        }
    }

    public void Button_Clicked(object sender, EventArgs e)
    {
        if (entry1.Text == "")
        {
            MessageBox.Show("Lüen Boş Bırakmayınız.");
            return;
        }
        string[] Bells_T = entry1.Text.Split(' ');
        if (Bells_T.Count() != 2)
        {
            MessageBox.Show("Hatalı Giriş Lüen Tekrarlayınız.");
            entry1.Text = "";
            return;
        }
        foreach (string var in Bells_T)
        {
            if (var == "")
            {
                MessageBox.Show("Hatalı Giriş Lüen Tekrarlayınız.");
                entry1.Text = "";
                return;
            }
        }
        int a = Convert.ToInt32(Bells_T[0]);
        int b = Convert.ToInt32(Bells_T[1]);
        Bell_Prop temp;
        if (a < 24 && a > -1 && b < 60 && b > -1)
        {
            temp = new Bell_Prop(a, b);
            if (Bells.Count != 0)
            {
                foreach (Bell_Prop var in Bells)
                {
                    if (var.Hour == temp.Hour && var.Minute == temp.Minute)
                    {
                        MessageBox.Show("Böe Bir Zil Zaten Mevcut Zil Silindi.");
                        Bells.Remove(var);
                        textview1.Buffer.Text = "";
                        var iter1 = this.textview1.Buffer.GetIterAtLine(0);
                        foreach (Bell_Prop var1 in Bells)
                        {
                            this.textview1.Buffer.InsertWithTags(ref iter1, "" + var1.Hour + " " + var1.Minute + "\n");
                        }
                        entry1.Text = "";
                        return;
                    }
                }
                Bells.Add(temp);
                entry1.Text = "";
            }
            else
            {
                Bells.Add(temp);
                entry1.Text = "";
            }

        }
        else
        {
            MessageBox.Show("Hatalı Giriş Lüen Tekrarlayınız.");
            entry1.Text = "";
            return;
        }
        textview1.Buffer.Text = "";
        var iter = this.textview1.Buffer.GetIterAtLine(0);
        foreach (Bell_Prop var in Bells)
        {
            this.textview1.Buffer.InsertWithTags(ref iter, "" + var.Hour + " " + var.Minute + "\n");

        }


    }
}
