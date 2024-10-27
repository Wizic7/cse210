using System.Collections.Concurrent;

class Reference {
    private String _book;
    private String _chapter;
    private String _verses;

    public Reference(String book, String chapter, String verses) {
        _book = book;
        _chapter = chapter;
        _verses = verses;
    }
    public String getReference() {
        return _book + " " + _chapter + ":" + _verses + " ";
    }
}