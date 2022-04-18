async function generateTableShopingCart(){
    if(IdVideoCartMas.length == 0)
        return `<h2 class="p-3 text-center" 
            style="position: relative; color: #bbaacf !important; top: 350px;">
            Shoping Cart is empty
        </h2>`

    
     let videoCartsHtml = "";
     //alert("succes1")
     for (let i = 0; i < IdVideoCartMas.length; i++) {
         //alert("succes2")

         videoCartsHtml += await GetVedeoCartById(IdVideoCartMas[i]);
     }
     //alert("succes1")
     return vTableStart + videoCartsHtml + vTableEnd + getButtons() + divEnd;
}

async function GetVedeoCartById(id)
{
    //alert(`GetVedeoCartById ${id}`)
    const response = await fetch(`https://localhost:44315/videocart/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (response.status == 200) {
        const videoCart = await response.json(); 

        return generateTableRow(videoCart);
    }
    else if (response.status == 204){
        alert("error");
        return "";
    }   
}
function generateTableRow(videoCart)
{// class="btn btn-outline-light btn-floating"
    return `
    <tr id="tr${videoCart.id}">
    <td style="width:0px;">
      <a id="plus" 
            style="position:relative; top:30px;"
            role="button" 
            onclick="sliceToCart(${videoCart.id})">
            <i class="fa-solid fa-trash-can" style='font-size:24px'></i>
            </a>
    </td>
    <td>
      <img src="${videoCart.img}" 
        width="100px" height="100px" alt="lorem">
    </td>
    <td class="text-center">
      <h6 style="position:relative; top:35px;" >${videoCart.name}</h6>
    </td>
    <td class="text-center">
      <h6 style="position:relative; top:35px;" >${videoCart.category}</h6>
    </td>
    <td class="text-center">
      <h6 style="position:relative; top:35px;">${videoCart.price} UAH</h6>
    </td>
    <td class="text-center" style="position:relative; width:180px; right:35px;">
        <div id="counter${videoCart.id}" >
            <button id="minus" 
            class="btn btn-outline-info btn-sm btn-floating" 
            style="position:relative; top:30px;  role="button" 
            onclick="minusNum(${videoCart.id})">-</button>

            <span class="m-2 text-center" 
                style="position:relative; font-size: 125%; top:32px;" id="number">
                1
            </span>

            <button id="plus" 
            class="btn btn-outline-info btn-sm btn-floating" 
            style="position:relative; top:30px;  role="button" 
            onclick="plusNum(${videoCart.id})">+</button>
        </div>
    </td>
    </tr>
    `;

}
//<input type="number" value="1" onkeypress="return false" class="num" >
function getButtons(){
    return `
    <br>
    <div class="m-2">
        <button style="position:relative; left:300px;"
            onclick="router.loadRoute('videocarts')"
            type="button" class="btn btn-info btn-rounded btn-lg">
            Back to shopping
        </button>
        <button type="button" style="position:relative; left:600px;" 
            onclick="createOrder();"
            class="btn btn-success btn-rounded btn-lg">
            Accept
        </button>
        </div>
    <br>
    <br>`;
}