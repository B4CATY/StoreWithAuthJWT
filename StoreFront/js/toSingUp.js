async function toSingUp(){
        // console.log("toSingUp start")
        //form.preventDefault();
        //alert("registerForm");
        const name = document.getElementById("typeNameX").value;
        const email = document.getElementById("typeEmailX").value;
        const password = document.getElementById("typePasswordX").value;
        userSignUp = {
            name: name,
            email: email,
            password: password
        };
        
        document.getElementById("typeNameX").value = "";
        document.getElementById("typeEmailX").value = "";
        document.getElementById("typePasswordX").value = "";

        localStorage.setItem("name", userSignUp.name);
        localStorage.setItem("email", userSignUp.email);
        await CreateUser(userSignUp);


        
        //form.preventDefault();    
}

async function CreateUser(user){
    // const userSignUp = {
    //         name: "TheBestUser1",
    //         email: "TheBestUser1@gmail.com",
    //         password: "User_password1"
    //     };

     const response = await fetch("https://localhost:44380/api/Users/register", {
                method: "POST",
                headers: { "Content-Type": "application/json" },
                body: JSON.stringify({
                    name: user.name,
                    Email: user.email,
                    password: user.password
                })
            });
            if (response.status == 200) {
                const data = await response.json();

                localStorage.setItem("JWT_Access", data.acces);
                localStorage.setItem("JWT_Refresh", data.refresh);
                await getRole();
                
            }
            else if(response.status == 404) {
                const errors = await response.json();
                //alert("CreateUser fail");
                createErrorSpan(errors);
                localStorage.removeItem("name");
                localStorage.removeItem("email");
            }
            
}

function createErrorSpan(errors)
{

    let erorsSpanEmail = `<label  style=" position: relative;">`;
    let erorsSpanPassword = `<label  style="position: relative; ">`;
    for (let i = 0; i < errors.length; i++) 
    {
        if(-1 < errors[i].indexOf('mail')){
            erorsSpanEmail += `<span 
            style=" position: fixed; font-size: 75%; left: 738px;" 
            class="text-warning" >
            ${errors[i]}</span> <br>`
        }
        else{
            erorsSpanPassword += `<span 
            style=" position: fixed; font-size: 75%; left: 738px;" 
            class="text-warning" >
            ${errors[i]}</span> <br>`
        }
    }
    document.querySelector("#errorEmail").innerHTML = erorsSpanEmail + `</label>`;
    document.querySelector("#errorPassword").innerHTML = erorsSpanPassword+ `</label> <br> `;
   
}