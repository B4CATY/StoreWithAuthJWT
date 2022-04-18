
const routes = [
  {
    path: '/',
    getTemplate: (params) => `<h1>Home</h1>`
  },

  {
    path: '/sign-in',
    getTemplate: (params) => 
    { 
        if(localStorage.getItem("name") === null)
            return singIn;
        
        else
            location.href = '/';
    },
  },

  {
    path: '/sign-up',
    getTemplate: (params) => 
    {
        if(localStorage.getItem("name") === null)
            return singUp;
        
        else
            location.href = '/';
    },
  },

  {
    path: '/videocarts',
    getTemplate: (params) => createVideoCartTable(1),
  },
  {
    path: '/videocarts/:Id',
    getTemplate: (params) => createVideoCartTable(params.Id),
  },
  {
    path: '/categories/:Id',
    getTemplate: (params) => createVideoCartTableById(params.Id),
  },
  {
    path: '/orders',
    getTemplate: (params) => generateOrders(),
  },
  {
    path: '/shoping-cart',
    getTemplate: (params) => generateTableShopingCart(),
  },
  {
    path: '/editname',
    getTemplate: (params) => changeName,
  },
  {
    path: '/create-category',
    getTemplate: (params) =>
    {
        if(localStorage.getItem("role") == "admin")
            return createCategoryView;
        
        else
            location.href = '/';
    },
  },
  {
    path: '/remove-category',
    getTemplate: (params) => removeCategoryForm(),
  },
  {
    path: '/create-videocart',
    getTemplate: (params) => creteVideocartForm(),
  },
  {
    path: '/remove-videocart',
    getTemplate: (params) => removeVideoCartForm(),
  },
  
];
//${params.Id}