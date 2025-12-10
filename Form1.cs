using System;
using System.Drawing;
using System.Windows.Forms;

namespace CalcoloBEP
{
    public partial class Form1 : Form
    {
        // Dati iniziali
        private double prezzoVendita = 50;
        private double costoVariabileUnitario = 30;
        private double costiFissiTotali = 40000;
        private int quantitaPrevista = 3000;

        private TextBox txtPrezzo;
        private TextBox txtCostoVariabile;
        private TextBox txtCostiFissi;
        private TextBox txtQuantitaPrevista;
        private Label lblMargineContribuzione;
        private Label lblBEPUnita;
        private Label lblBEPValore;
        private Label lblRisultatoOperativo;
        private Label lblStatoUtile;
        private Button btnCalcola;
        private Button btnReset;

        public Form1()
        {
            
            InizializzaComponenti();
            Calcola();
        }

        private void InizializzaComponenti()
        {
            this.Text = "Calcolo Break Even Point";
            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Titolo
            Label titolo = new Label
            {
                Text = "ANALISI BREAK EVEN POINT",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                Location = new Point(80, 20),
                Size = new Size(350, 30),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Pannello dati input
            GroupBox gbInput = new GroupBox
            {
                Text = "Dati di Input",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(30, 60),
                Size = new Size(430, 150)
            };

            // Prezzo di vendita
            Label lblPrezzo = new Label
            {
                Text = "Prezzo di vendita unitario (€):",
                Location = new Point(20, 30),
                Size = new Size(200, 20)
            };

            txtPrezzo = new TextBox
            {
                Text = prezzoVendita.ToString(),
                Location = new Point(250, 28),
                Size = new Size(80, 20)
            };

            // Costo variabile unitario
            Label lblCostoVariabile = new Label
            {
                Text = "Costo variabile unitario (€):",
                Location = new Point(20, 60),
                Size = new Size(200, 20)
            };

            txtCostoVariabile = new TextBox
            {
                Text = costoVariabileUnitario.ToString(),
                Location = new Point(250, 58),
                Size = new Size(80, 20)
            };

            // Costi fissi totali
            Label lblCostiFissi = new Label
            {
                Text = "Costi fissi totali (€):",
                Location = new Point(20, 90),
                Size = new Size(200, 20)
            };

            txtCostiFissi = new TextBox
            {
                Text = costiFissiTotali.ToString(),
                Location = new Point(250, 88),
                Size = new Size(80, 20)
            };

            // Quantità prevista
            Label lblQuantitaPrevista = new Label
            {
                Text = "Quantità prevista di vendita:",
                Location = new Point(20, 120),
                Size = new Size(200, 20)
            };

            txtQuantitaPrevista = new TextBox
            {
                Text = quantitaPrevista.ToString(),
                Location = new Point(250, 118),
                Size = new Size(80, 20)
            };

            // Aggiungi controlli al GroupBox
            gbInput.Controls.AddRange(new Control[] {
                lblPrezzo, txtPrezzo,
                lblCostoVariabile, txtCostoVariabile,
                lblCostiFissi, txtCostiFissi,
                lblQuantitaPrevista, txtQuantitaPrevista
            });

            // Pannello risultati
            GroupBox gbRisultati = new GroupBox
            {
                Text = "Risultati",
                Font = new Font("Arial", 10, FontStyle.Bold),
                Location = new Point(30, 220),
                Size = new Size(430, 180)
            };

            // Margine di contribuzione
            Label lblMargineTitolo = new Label
            {
                Text = "Margine di contribuzione unitario:",
                Location = new Point(20, 30),
                Size = new Size(250, 20)
            };

            lblMargineContribuzione = new Label
            {
                Text = "",
                Location = new Point(280, 30),
                Size = new Size(120, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.DarkGreen
            };

            // BEP in unità
            Label lblBEPUnitaTitolo = new Label
            {
                Text = "Break Even Point (unità):",
                Location = new Point(20, 60),
                Size = new Size(250, 20)
            };

            lblBEPUnita = new Label
            {
                Text = "",
                Location = new Point(280, 60),
                Size = new Size(120, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };

            // BEP in valore
            Label lblBEPValoreTitolo = new Label
            {
                Text = "Break Even Point (valore €):",
                Location = new Point(20, 90),
                Size = new Size(250, 20)
            };

            lblBEPValore = new Label
            {
                Text = "",
                Location = new Point(280, 90),
                Size = new Size(120, 20),
                Font = new Font("Arial", 9, FontStyle.Bold),
                ForeColor = Color.DarkBlue
            };

            // Risultato operativo
            Label lblRisultatoTitolo = new Label
            {
                Text = "Risultato operativo (€):",
                Location = new Point(20, 120),
                Size = new Size(250, 20)
            };

            lblRisultatoOperativo = new Label
            {
                Text = "",
                Location = new Point(280, 120),
                Size = new Size(120, 20),
                Font = new Font("Arial", 9, FontStyle.Bold)
            };

            // Stato utile
            lblStatoUtile = new Label
            {
                Text = "",
                Location = new Point(20, 150),
                Size = new Size(380, 20),
                Font = new Font("Arial", 10, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Aggiungi controlli al GroupBox risultati
            gbRisultati.Controls.AddRange(new Control[] {
                lblMargineTitolo, lblMargineContribuzione,
                lblBEPUnitaTitolo, lblBEPUnita,
                lblBEPValoreTitolo, lblBEPValore,
                lblRisultatoTitolo, lblRisultatoOperativo,
                lblStatoUtile
            });

            // Pulsanti
            btnCalcola = new Button
            {
                Text = "CALCOLA",
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.SteelBlue,
                ForeColor = Color.White,
                Location = new Point(120, 410),
                Size = new Size(120, 35),
                Cursor = Cursors.Hand
            };

            btnReset = new Button
            {
                Text = "RESET",
                Font = new Font("Arial", 10, FontStyle.Bold),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                Location = new Point(260, 410),
                Size = new Size(120, 35),
                Cursor = Cursors.Hand
            };

            // Aggiungi event handler
            btnCalcola.Click += BtnCalcola_Click;
            btnReset.Click += BtnReset_Click;

            // Aggiungi tutti i controlli al form
            this.Controls.AddRange(new Control[] {
                titolo,
                gbInput,
                gbRisultati,
                btnCalcola,
                btnReset
            });
        }

        private void BtnCalcola_Click(object sender, EventArgs e)
        {
            try
            {
                // Leggi i valori dai TextBox
                prezzoVendita = Convert.ToDouble(txtPrezzo.Text);
                costoVariabileUnitario = Convert.ToDouble(txtCostoVariabile.Text);
                costiFissiTotali = Convert.ToDouble(txtCostiFissi.Text);
                quantitaPrevista = Convert.ToInt32(txtQuantitaPrevista.Text);

                Calcola();
            }
            catch (FormatException)
            {
                MessageBox.Show("Inserire valori numerici validi in tutti i campi.",
                    "Errore di input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Ripristina valori iniziali
            txtPrezzo.Text = "50";
            txtCostoVariabile.Text = "30";
            txtCostiFissi.Text = "40000";
            txtQuantitaPrevista.Text = "3000";

            prezzoVendita = 50;
            costoVariabileUnitario = 30;
            costiFissiTotali = 40000;
            quantitaPrevista = 3000;

            Calcola();
        }

        private void Calcola()
        {
            // Calcola margine di contribuzione unitario
            double margineContribuzione = prezzoVendita - costoVariabileUnitario;

            // Calcola BEP in unità
            double bepUnita = costiFissiTotali / margineContribuzione;

            // Calcola BEP in valore
            double bepValore = bepUnita * prezzoVendita;

            // Calcola risultato operativo per la quantità prevista
            double risultatoOperativo = (margineContribuzione * quantitaPrevista) - costiFissiTotali;

            // Aggiorna le label con i risultati
            lblMargineContribuzione.Text = $"{margineContribuzione:F2} €";
            lblBEPUnita.Text = $"{bepUnita:F0} unità";
            lblBEPValore.Text = $"{bepValore:F2} €";
            lblRisultatoOperativo.Text = $"{risultatoOperativo:F2} €";

            // Determina il colore e lo stato del risultato
            if (risultatoOperativo > 0)
            {
                lblRisultatoOperativo.ForeColor = Color.Green;
                lblStatoUtile.Text = $"✓ UTILE: La vendita di {quantitaPrevista} unità supera il BEP di {bepUnita:F0} unità";
                lblStatoUtile.ForeColor = Color.Green;
            }
            else if (risultatoOperativo < 0)
            {
                lblRisultatoOperativo.ForeColor = Color.Red;
                lblStatoUtile.Text = $"✗ PERDITA: La vendita di {quantitaPrevista} unità è inferiore al BEP di {bepUnita:F0} unità";
                lblStatoUtile.ForeColor = Color.Red;
            }
            else
            {
                lblRisultatoOperativo.ForeColor = Color.Blue;
                lblStatoUtile.Text = $"PAREGGIO: La vendita di {quantitaPrevista} unità corrisponde esattamente al BEP";
                lblStatoUtile.ForeColor = Color.Blue;
            }
        }
    }
}