using System.Runtime.CompilerServices;
namespace stagiaireCRUD.Models;
public class Etudiant
{
    public int Id
    {
        get;
        set;
    }
    public string Nom
    {
        get;
        set;
    }
    public String prenom
    {
        get;
        set;
    }

    public DateTime DebutStage
    {
        get;
        set;
    }

        public String Email
    {
        get;
        set;
    }
    
    public String Etablissement
    {
        get;
        set;
    }
}