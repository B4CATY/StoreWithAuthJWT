async function removeVideoCartForm(){
    if(localStorage.getItem("role") == "admin"){
        const removeVideoCartViewBody =  await createSelectVideocart();
        console.log(removeVideoCartViewBody);
        return removeVideoCartViewStart + removeVideoCartViewBody + removeVideoCartViewEnd;
    }
    
    else
        location.href = '/';
    
}
//await GetVideoCarts()

async function createSelectVideocart(){
    const videocarts = await GetVideoCartsBaseInfo();
    let selectVideocartsHtml = ``;
    if(videocarts != null){
        for (const videocart of videocarts) {
            selectVideocartsHtml += createSelect(videocart).toString();
        }
    }
    return selectVideocartsHtml;
}


async function GetVideoCartsBaseInfo() {
    
    const response = await fetch(`https://localhost:44315/VideoCarts`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    });
    if (response.status == 200) {
        return await response.json(); 

    }
    else if (response.status == 204){
        return null;
    }
    else 
        alert("error");
        
    
   
}