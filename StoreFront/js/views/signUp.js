
const singUp = `<div id="registerForm" class="vh-100">
<div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
        <div class="col-12 col-md-8 col-lg-6 col-xl-5">
            <div class="card bg-dark text-white" style="border-radius: 1rem;">
                <div class="card-body p-5 text-center">

                    <div class="mb-md-5 mt-md-4 pb-5">

                        <h2 class="fw-bold mb-2 text-uppercase">Register</h2>
                        <p class="text-white-50 mb-5">Please fill in the registration form!</p>

                        <div class="form-outline form-white mb-4">
                            <input type="email name="email"" id="typeEmailX" class="form-control form-control-lg" />
                            <label class="form-label" for="typeEmailX">Email</label>
                            <div id="errorEmail"></div>
                        </div>
                        <div class="form-outline form-white mb-4">
                            <input type="username" name="name" id="typeNameX" class="form-control form-control-lg" />
                            <label class="form-label" for="typeNameX">Name</label>
                        </div>
                        <div class="form-outline form-white mb-4">
                            <input type="password" name="password" id="typePasswordX" class="form-control form-control-lg" />
                            <label class="form-label" for="typePasswordX">Password</label>
                            <div id="errorPassword"></div>
                        </div>


                        <button class="btn btn-outline-light
                         btn-rounded ripple-surface btn-lg px-5"
                         onclick="toSingUp();"
                         type="submit">Register</button>
                    </div>

                    <div>
                        <p class="mb-0">
                            Do you have an account? <a role="button" onclick="router.loadRoute('sign-in')" class="text-white-50 fw-bold">Sign In</a>
                        </p>
                    </div>

                </div>
            </div>
        </div>
    </div>
</div>`;


// const singUp =`<form name="registerForm" style="position: relative; top: 300px;">
//         <div class="form-group col-md-5">
//             <label class="text-warning" for="name">name:</label>
//             <input class="form-control" name="name" />
//         </div>
//         <div class="form-group col-md-5">
//             <label class="text-warning" for="age">email:</label>
//             <input class="form-control" name="email" />
//         </div>
//         <div class="form-group col-md-5">
//             <label class="text-warning" for="age">password:</label>
//             <input class="form-control" name="password" />
//         </div>
//         <div class="panel-body">
//             <button onclick="toSingUp()" id="submit" class="btn btn-primary">Сохранить</button>
//             <a id="reset" class="btn btn-primary">Сбросить</a>
//         </div>
//     </form>`