class Word{
    private String _word;
    private Boolean _is_hidden;

    public Word(String word) {
        this._word = word;
    }
    public String getWord() {
        if(this._is_hidden == true) {
            String hiddenchars = "";
            for(int x = 0; x < _word.Length; x++) {
                hiddenchars += "_";
            }
            return hiddenchars;
        }
        return _word;
    }

    public void hideWord() {
        this._is_hidden = true;
    }

    public void reset() {
        this._is_hidden = false;
    }
}