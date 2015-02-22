function CTParser(str) {
    /* fields
     * */
    var _stream = str;
    var _arr = null;

/*methods
* */
    var parse = function(){
        //split text to sentences
        var _sentences = _stream.split('.');
        _arr = [];
        for (var i = 0; i < _sentences.length; i++) {
            _arr[i] = null;
            //find separator '-'
            if (_sentences[i].indexOf(" - ") >= 0){
                _arr[i] =   splitSentences(_sentences[i],' - ');
            }
            else{
                if (_sentences[i].indexOf(" це ") >= 0){
                    _arr[i] =   splitSentences(_sentences[i],' це ');
                }
            }
            //find separator '—'
            if (_sentences[i].indexOf(" — ") >= 0){
                _arr[i] =   splitSentences(_sentences[i],' — ');
            }else{
                if (_sentences[i].indexOf(" це ") >= 0){
                    _arr[i] =   splitSentences(_sentences[i],' це ');
                }
            }


        }
        return _arr;
    }

    var splitSentences = function (sentence,separator){
        var ptElement = sentence.split(separator);
        if(ptElement[0].length<ptElement[1].length){
            return new CTElement(ptElement[0],ptElement[1])
        }
        else {
            return new CTElement(ptElement[1],ptElement[0])
        }
    }
     this.getCTArr = function(){
        return parse();
    }
}







function CTElement(concept,thesis) {
    /* fields
     * */
    this.concept = concept;
    this.thesis = thesis;

}