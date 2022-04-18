async function generateOrders(){
    const tableOrdedsBody = await getOrders();

    return tableOrdersStart + tableOrdedsBody + tableOrdersEnd;
}