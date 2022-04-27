export class  Product{
    constructor(videcart, category, price){
        this.videcart = videcart;
        this.category = category
        this.price = price
    }
    static setColour(){
        //let sss = $('#trBody').last().html();
         $(".trBody:odd").css('background-color', 'blue');
         $(".trBody:even").css('background-color', 'red');
         let list = $(".tableId").children(".trBody");
         list.each(function(index,elem){
            console.log(elem.innerHTML + " " + index);
        })
        //console.log(sss)
    }

}
