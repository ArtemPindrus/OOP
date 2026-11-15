namespace Project;

public class Pipeline {
    public string Format(string str, params Formater[] formaters) {
        foreach (var f in formaters) {
            str = f.Format(str);
        }

        return str;
    }
}