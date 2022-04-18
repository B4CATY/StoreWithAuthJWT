function pushToCart(videoCartId){
    if(localStorage.getItem("name") == null){
        router.loadRoute('sign-in');
        
    }
    else{
        if(IdVideoCartMas.length == 0 
            ||IdVideoCartMas.indexOf(+videoCartId) == -1)
        {
            console.log(IdVideoCartMas);
            IdVideoCartMas.push(+videoCartId);
        }
    }
    
    
}

function sliceToCart(videoCartId){
    
    console.log("before: " + IdVideoCartMas)
    let index = IdVideoCartMas.indexOf(+videoCartId)
    if(index != -1){
        IdVideoCartMas.splice(index, 1);
        console.log("after: " + IdVideoCartMas)
        document.querySelector(`#tr${videoCartId}`).innerHTML = "";
    }
        
}

async function createOrder(){

    countVideoCart = [];
    const email = localStorage.getItem("email");
    document.querySelectorAll('span')
        .forEach(x =>
            { 
                if(+x.innerText > 0)
                    countVideoCart.push(+x.innerText);
            });
    
    //alert(countVideoCart);
    const token = localStorage.getItem("JWT_Access");
    const response = await fetch(`https://localhost:44315/orders/create`, {
        method: 'POST',
        headers: {
            "Accept": "application/json", 
            "Content-Type": "application/json",
            "Authorization": "Bearer " + token
        },
        body: JSON.stringify({
            email: localStorage.getItem("email"),
            idVideoCart: IdVideoCartMas,
            countVideoCart: countVideoCart
        })
    });
    //alert(response.status);
    if (response.status == 200) {
       //alert("succes");
       location.href = '/';
    }
    else if (response.status == 401){
        await refresh();
        
        await createOrder();
    } 
    else if (response.status == 400){
        alert("error");
    }   
}