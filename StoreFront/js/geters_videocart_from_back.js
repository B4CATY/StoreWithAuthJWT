async function GetVideoCarts(id) {
    
    const response = await fetch(`https://localhost:44315/VideoCarts/${id}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (response.status == 200) {
        return await response.json(); 

    }
    else if (response.status == 204){
        return "";
    }
        
    
   
}

async function GetCount(name) {
    const response = await fetch(`https://localhost:44315/${name}/count`, {
        method: 'GET',
        headers: {
            "Content-Type": "application/json"
        }
    });
    if (response.status == 200) {

        const videoCartsCount = await response.json(); 

        return Number(videoCartsCount.count);

    }
    else if (response.status == 404){
        return null;
    }
    
   
}
