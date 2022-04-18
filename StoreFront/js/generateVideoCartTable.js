async function createVideoCartTable(id){

    const videoCarts = await GetVideoCarts(id);
    let vTableBody = ``;
    for (const videoCart of videoCarts) {
        vTableBody += rowVideoCart(videoCart);
    }
    
    const table = vTableStart  + vTableBody + vTableEnd + paginationHtml + divEnd;
     
    pagination_start(id, 'videocarts');
    return table;
}





function rowVideoCart(videoCart) {
 
    return `
    <tr class="text-center">
    <td  style="width:0px;">
      <h6 style="position:relative; top:35px;" >${videoCart.id}</h6>
    </td>
    <td >
      <img src="${videoCart.img}" 
        width="100px" height="100px" alt="lorem">
    </td>
    <td>
      <h6 style="position:relative; top:35px;">${videoCart.name}</h6>
    </td>
    <td >
      <h6 style="position:relative; top:35px;">${videoCart.category}</h6>
    </td>
    <td >
      <h6 style="position:relative; top:35px;" >${videoCart.price} UAH</h6>
    </td>
    <td >
      <button class="btn btn-outline-info"
        id="button${videoCart.id}" onclick="pushToCart(${videoCart.id})"
        style="position:relative; top:25px;">
        
        Add to cart
        </button>
    </td>
    </tr>
    `;
    
}

