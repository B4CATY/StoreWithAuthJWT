async function generateOrderTable(id)
{
    const tableOrderBody = await getOrder(id);
    document.querySelector("#tableOrders").innerHTML = 
        tableOrderStart + tableOrderBody + tableOrderEnd
}