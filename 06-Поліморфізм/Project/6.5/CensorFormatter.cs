using System.Text;

namespace Project;

public class CensorFormatter : Formater {
    private readonly string[] censoredWords;

    public CensorFormatter(string[] words) {
        this.censoredWords = words;
    }

    public override string Format(string str) {
        StringBuilder sb = new(str);

        foreach (var w in censoredWords) {
            sb.Replace(w, new('*', w.Length));
        }

        return sb.ToString();
    }
}