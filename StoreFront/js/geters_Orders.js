async function getOrders(){
    const email = localStorage.getItem("email");
    const token = localStorage.getItem("JWT_Access");
    
    const response = await fetch(`https://localhost:44315/orders?Email=${email}`, {
        method: 'GET',
        headers: {
            "Accept": "application/json", 
            "Content-Type": "application/json",
            "Authorization": "Bearer " + token
        }
    });
    if (response.status == 200) {
        const orders = await response.json()
        let ordersHtml = "";
        for (const order of orders) {
            ordersHtml+=createOrdersTr(order);
        }
        //location.href = '/';
        console.log(ordersHtml);
        return ordersHtml;
    }
    else if (response.status == 401){
        await refresh();
        
        return await getOrders();
    } 
    else if (response.status == 400){
        alert("error");
    }   
    
}

function createOrdersTr(order){
    return `
        <tr onclick="generateOrderTable(${order.orderId})" role="button">
            <td class="text-md-center" >
                ${order.orderId}
            </td>
            <td class="text-md-center">
                ${order.purchaseDate}
            </td>
        </tr>
    `;
}