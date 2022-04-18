async function GetCategories() {
    
    const response = await fetch(`https://localhost:44315/Categories`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (response.status == 200) {
        const categories = await response.json(); 
        
        
        
        return categories;
    }
    else if (response.status == 204){
        return "";
    }
}



async function GetVideoCartsByCategories(id) {
    
    const response = await fetch(`https://localhost:44315/Categories/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (response.status == 200) {
        const videoCarts = await response.json(); 
        let videoCartsHtml = "";
        for (const videoCart of videoCarts) {
            videoCartsHtml += rowVideoCart(videoCart);
        }
        
        return videoCartsHtml.toString();
    }
    else if (response.status == 404){
        return "";
    }
        
    
   
}