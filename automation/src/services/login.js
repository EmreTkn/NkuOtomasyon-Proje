import environment from '../../config/environments'
export class Login {
     baseUrl=environment.baseUrl;
     login(email,password){
        return fetch(baseUrl+"/account/login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body:{
                "email": email,
                "password": password
               }
        }).then(function(response) {
            return response.json();
        }).then(function(data){
            return data.type;
        });
     }

}