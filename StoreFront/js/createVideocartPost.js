async function videocartPost(videocart){
    const token = localStorage.getItem("JWT_Access");
    
    const response = await fetch("https://localhost:44315/admin/videocarts/create", {
        method: "POST",
        headers: { 
            "Content-Type": "application/json",
            "Authorization": "Bearer " + token 
        },
        body: JSON.stringify(videocart)
    });
    if (response.status == 204) {
        //alert("success");
        
        router.loadRoute('');
    }
    else if (response.status == 401){
        
        let result = await refresh();
        if(result == 200)
            await videocartPost(videocart);
    }
    else if (response.status == 405){
        await logout();
    }
    else{
        alert("error")
    }
}