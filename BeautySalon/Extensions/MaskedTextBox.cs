using System;
using System.Text;
using System.Windows.Controls;

namespace BeautySalon.Extensions
{
    public class MaskedTextBox : TextBox
    {
        public TextBoxMask Mask { get; set; }

        public MaskedTextBox()
        {
            this.TextChanged += new TextChangedEventHandler(MaskedTextBox_TextChanged);
        }

        void MaskedTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.CaretIndex = this.Text.Length;

            var tbEntry = sender as MaskedTextBox;

            if (tbEntry != null && tbEntry.Text.Length > 0)
            {
                tbEntry.Text = formatNumber(tbEntry.Text, tbEntry.Mask);
            }
        }

        public static string formatNumber(string text, TextBoxMask mask)
        {
            int x;
            StringBuilder sb = new StringBuilder();

            if (text != null)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (int.TryParse(text.Substring(i, 1), out x))
                    {
                        sb.Append(x.ToString());
                    }
                }
                switch (mask)
                {
                    case TextBoxMask.CEP:
                        return FormataCep(sb.ToString()).ToString();

                    case TextBoxMask.CPF:
                        return FormataCpf(sb.ToString()).ToString();

                    case TextBoxMask.Telefone:
                        return FormataTelefone(sb.ToString()).ToString();

                    case TextBoxMask.CNPJ:
                        return FormataCnpj(sb.ToString()).ToString();

                    default:
                        break;
                }

            }
            return sb.ToString();
        }

        public static StringBuilder FormataCep(string sb)
        {
            var sb2 = new StringBuilder();

            return sb2;
        }

        public static StringBuilder FormataCpf(string sb)
        {
            var sb2 = new StringBuilder();

            return sb2;
        }

        public static StringBuilder FormataCnpj(string sb)
        {
            var sb2 = new StringBuilder();

            return sb2;
        }

        public static StringBuilder FormataTelefone(string sb)
        {
            StringBuilder sb2 = new StringBuilder();

            if (sb.Length > 0) sb2.Append("(");

            if (sb.Length > 0) sb2.Append(sb.Substring(0, 1));
            if (sb.Length > 1) sb2.Append(sb.Substring(1, 1));

            if (sb.Length > 2) sb2.Append(") ");

            if (sb.Length > 3) sb2.Append(sb.Substring(3, 1));
            if (sb.Length > 4) sb2.Append(sb.Substring(4, 1));
            if (sb.Length > 5) sb2.Append(sb.Substring(5, 1));

            if (sb.Length > 6) sb2.Append("-");

            if (sb.Length > 6) sb2.Append(sb.Substring(6, 1));
            if (sb.Length > 7) sb2.Append(sb.Substring(7, 1));
            if (sb.Length > 8) sb2.Append(sb.Substring(8, 1));
            if (sb.Length > 9) sb2.Append(sb.Substring(9, 1));

            return sb2;
        }
    }

    public enum TextBoxMask
    {
        Telefone,
        CEP,
        CPF,
        CNPJ
    }
}
