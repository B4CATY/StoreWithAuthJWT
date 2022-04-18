function minusNum(id) {
    const divCounter = document.querySelector(`#counter${id}`);
    if(+divCounter.querySelectorAll('span')[0].innerHTML > 1)
        --divCounter.querySelectorAll('span')[0].innerHTML;
}

function plusNum(id) {
    const divCounter = document.querySelector(`#counter${id}`);
    if(+divCounter.querySelectorAll('span')[0].innerHTML < 10000)
        ++divCounter.querySelectorAll('span')[0].innerHTML;

}