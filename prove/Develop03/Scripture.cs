using System.Data;
using System.Runtime.CompilerServices;

class Scripture{
    private List<Word> _words = new List<Word>();

    private int[] _randomIndex;
    private int _currentIndex = 0;
    private Reference _reference;

    public Scripture() {
        String verse = "1 Nephi 3:7 And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.";
        int collinPos = verse.IndexOf(':');
        int chapterStart = verse.IndexOf(' ', collinPos-4);
        int referenceEnd = verse.IndexOf(' ', collinPos);

        String book = verse.Substring(0, chapterStart).Trim();
        String chapter = verse.Substring(chapterStart, collinPos-chapterStart).Trim();
        String verses = verse.Substring(collinPos+1, referenceEnd-collinPos).Trim();

        _reference = new Reference(book, chapter, verses);
        verse = verse.Substring(referenceEnd).Trim();

        String[] Temp = verse.Split(' ');
        _randomIndex = Enumerable.Range(0,Temp.Length).ToArray();
        shuffleIndex();

        for(int x=0; x<Temp.Length; x++){
            Word tempWord = new Word(Temp[x]);
            this._words.Add(tempWord);
        }
    }
    public Scripture(String verse){
        int collinPos = verse.IndexOf(':');
        int chapterStart = verse.IndexOf(' ', collinPos-4);
        int referenceEnd = verse.IndexOf(' ', collinPos);

        String book = verse.Substring(0, chapterStart).Trim();
        String chapter = verse.Substring(chapterStart, collinPos-chapterStart).Trim();
        String verses = verse.Substring(collinPos+1, referenceEnd-collinPos).Trim();


        _reference = new Reference(book, chapter, verses);
                verse = verse.Substring(referenceEnd).Trim();

        String[] Temp = verse.Split(' ');
        _randomIndex = Enumerable.Range(0,Temp.Length).ToArray();
        shuffleIndex();


        for(int x=0; x<Temp.Length; x++){
            _words.Add(new Word(Temp[x]));
        }
    }

    public void displayVerse(){
        Console.Clear();
        Console.Write(_reference.getReference());
        foreach(Word word in _words){
            Console.Write(word.getWord() + " ");
        }
    }

    public void hideWords() {
        int remaining = _randomIndex.Length - _currentIndex;
        if(remaining < 3){
            for(int i=0; i < remaining; i++){
            _words[_randomIndex[_currentIndex]].hideWord();
            _currentIndex++;
        }
        }
        else{
            for(int i=0; i < 3; i++){
                _words[_randomIndex[_currentIndex]].hideWord();
                _currentIndex++;
            }
        }
    }

    public void reset() {
        for(int i=0; i< _currentIndex; i++){
            _words[_randomIndex[i]].reset();
        }
        _currentIndex = 0;
        shuffleIndex();

    }
    private void shuffleIndex() {        
        Random random = new Random();
        for(int i = _randomIndex.Length-1; i > 0; i--){
            int rand = random.Next(0, i);
            (_randomIndex[rand], _randomIndex[i]) = (_randomIndex[i], _randomIndex[rand]);
        }
    }
}