async function creteVideocartForm(){
    if(localStorage.getItem("role") == "admin"){
            const createVideocartViewBody = await createSelectCategory();
            return createVideocartViewStart + createVideocartViewBody + createVideocartViewStartEnd;
        }
    else
        location.href = '/';
}

async function creteVideocart(){
    if(document.querySelector("#selectCategory").value == null 
        || +document.querySelector("#selectCategory").value < 1)
        return;

    if(document.querySelector("#typeNameX").value == null 
        || +document.querySelector("#typeNameX").value.length < 2)
        return;

    if(document.querySelector("#typePricedX").value == null 
        || +document.querySelector("#typePricedX").value < 1)
        return;
    
    if(document.querySelector("#typeImgdX").value == null 
        || +document.querySelector("#typeImgdX").value.length < 1)
        return;
    

    //alert("success");
    const selectCategory = +document.querySelector("#selectCategory").value;
    const nameCVideocart = document.querySelector("#typeNameX").value;
    const priceVideocart = +document.querySelector("#typePricedX").value;
    const imgVideocart = document.querySelector("#typeImgdX").value;

    const newVideocart= {
        name: nameCVideocart,
        categoryId: selectCategory,
        img: imgVideocart,
        price:priceVideocart
    };
    console.log(newVideocart);
    await videocartPost(newVideocart);
}

