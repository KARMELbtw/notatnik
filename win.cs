using System;
using System.Drawing;
using System.Windows.Forms;

public class notepad : Form
{

    MainMenu menu = new MainMenu();

    RichTextBox notatnik = new RichTextBox();

    static public void Main()
    {
        Application.Run(new notepad());

    }
    public notepad()
    {
        notatnik.Font = new Font(notatnik.Font.Name, 24);
        this.Size = new Size(800, 600);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Notepad";

        MenuItem plik = new MenuItem();
        MenuItem nowy = new MenuItem();
        MenuItem otworz = new MenuItem();
        MenuItem zapisz = new MenuItem();
        MenuItem drukuj = new MenuItem();
        MenuItem zamknij = new MenuItem();

        plik.Text = "&Plik";
        nowy.Text = "&Nowy";
        otworz.Text = "&Otwórz";
        zapisz.Text = "&Zapisz jako...";
        drukuj.Text = "&Drukuj";
        zamknij.Text = "&Zamknij";

        menu.MenuItems.Add(plik);
        plik.MenuItems.Add(nowy);
        plik.MenuItems.Add(otworz);
        plik.MenuItems.Add(zapisz);
        plik.MenuItems.Add(drukuj);
        plik.MenuItems.Add(zamknij);

        nowy.Shortcut = Shortcut.CtrlN;
        otworz.Shortcut = Shortcut.CtrlO;
        zapisz.Shortcut = Shortcut.CtrlS;
        drukuj.Shortcut = Shortcut.CtrlP;

        MenuItem edycja = new MenuItem();
        MenuItem kopiuj = new MenuItem();
        MenuItem wklej = new MenuItem();
        MenuItem usun = new MenuItem();
        MenuItem wytnij = new MenuItem();
        MenuItem kolor = new MenuItem();
        MenuItem czcionka = new MenuItem();

        edycja.Text = "&Edycja";
        kopiuj.Text = "&Kopiuj";
        wklej.Text = "&Wklej";
        usun.Text = "&Usuń";
        wytnij.Text = "&Wytnij";
        kolor.Text = "&Kolor";
        czcionka.Text = "&Czcionka";

        menu.MenuItems.Add(edycja);
        edycja.MenuItems.Add(kopiuj);
        edycja.MenuItems.Add(wklej);
        edycja.MenuItems.Add(wytnij);
        edycja.MenuItems.Add(usun);
        edycja.MenuItems.Add(kolor);
        edycja.MenuItems.Add(czcionka);
        
        kopiuj.Shortcut = Shortcut.CtrlC;
        wklej.Shortcut = Shortcut.CtrlV;
        usun.Shortcut = Shortcut.Del;
        wytnij.Shortcut = Shortcut.CtrlX;

        this.Menu = menu;


        this.Controls.Add(notatnik);
        notatnik.Dock = DockStyle.Fill;

        nowy.Click += new EventHandler(nowy_click);
        otworz.Click += new EventHandler(otworz_click);
        zapisz.Click += new EventHandler(zapisz_click);
        drukuj.Click += new EventHandler(drukuj_click);
        zamknij.Click += new EventHandler(zamknij_click);

        kopiuj.Click += new EventHandler(kopiuj_click);
        wklej.Click += new EventHandler(wklej_click);
        usun.Click += new EventHandler(usun_click);
        wytnij.Click += new EventHandler(wytnij_click);
        kolor.Click += new EventHandler(kolor_click);
        czcionka.Click += new EventHandler(czcionka_click);
    }

    private void nowy_click(object sender, EventArgs e)
    {
        if (notatnik.Text != "")
        {
            DialogResult dialog = MessageBox.Show("czy jesteś pewny ?", "Wyjście", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                notatnik.Clear();
            }
        }
        else
        {
            this.Close();
        }
    }
    private void otworz_click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Title = "Otwórz plik";
        dialog.Filter ="Pliki RTF|*.rtf|Pliki tekstowe TXT|*.txt";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
            notatnik.LoadFile(dialog.FileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
    private void zapisz_click(object sender, EventArgs e)
    {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Title = "Zapisz plik";
        dialog.Filter = "Pliki txt|*.txt";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            notatnik.SaveFile(dialog.FileName);
        }
    }
    private void drukuj_click(object sender, EventArgs e)
    {
        PrintDialog dialog = new PrintDialog();
        if (dialog.ShowDialog() == DialogResult.OK)
        {

        }
    }

    private void zamknij_click(object sender, EventArgs e)
    {
        if (notatnik.Text != "")
        {
            DialogResult dialog = MessageBox.Show("czy jesteś pewny ?", "Wyjście", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                this.Close();
            }
        }
        else
        {
            this.Close();
        }
    }

    private void czcionka_click(object sender, EventArgs e)
    {
        FontDialog dialog = new FontDialog();
        if(dialog.ShowDialog() == DialogResult.OK)
        {
            notatnik.SelectionFont = dialog.Font;
        }
    }

    private void kopiuj_click(object sender, EventArgs e)
    {
        notatnik.Copy();
    }
    private void wklej_click(object sender, EventArgs e)
    {
        notatnik.Paste();
    }

    private void kolor_click(object sender, EventArgs e)
    {
        ColorDialog dialog = new ColorDialog();
        if(dialog.ShowDialog() == DialogResult.OK)
        {
            notatnik.SelectionColor = dialog.Color;
        }
    }

    private void wytnij_click(object sender, EventArgs e)
    {
        notatnik.Cut();
    }
    private void usun_click(object sender, EventArgs e)
    {
        notatnik.Clear();
    }
}


