async function getOrder(id){
    const email = localStorage.getItem("email");
    const token = localStorage.getItem("JWT_Access");
    //alert("+response.status");
    const response = await fetch(`https://localhost:44315/order?Email=${email}&OrderId=${id}`, {
        method: 'GET',
        headers: {
            "Accept": "application/json", 
            "Content-Type": "application/json",
            "Authorization": "Bearer " + token
        }
    });
    //alert(+response.status);
    if (response.status == 200) {
        const order = await response.json()
        let tableOrderBody = "";
        for (const entity of order) {
            tableOrderBody+=rowOrderTable(entity);
        }
        //location.href = '/';
        
       
        return tableOrderBody;
    }
    else if (response.status == 401){
        await refresh();
        
        return await getOrders();
    } 
    else if (response.status == 400){
        alert("error");
    }   
}

function rowOrderTable(order){
    return `
    <tr class="text-center">
    <td>
      <img src="${order.img}" 
        width="100px" height="100px" alt="lorem">
    </td>
    <td>
      <h6 style="position:relative; top:35px;" >${order.name}</h6>
    </td>
    <td>
      <h6 style="position:relative; top:35px;" >${order.category}</h6>
    </td>
    <td>
      <h6 style="position:relative; top:35px;">${order.price} UAH</h6>
    </td>
    <td>
        <h6 style="position:relative; top:35px;">${order.quantity}</h6>
    </td>
    </tr>
    `
}