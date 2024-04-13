import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { LoginResponse, RegisterResponse, UpdateResponse } from "../common/api-responses";
import { UpdateProfileRequest } from "../common/large-request-interfaces";

@Injectable({
    providedIn: 'root'
})
export class UserService{
    constructor(private httpClient: HttpClient) {}

    public register(email: string, password: string, companyName: string | null, firstName: string, lastName: string, zipCode: number, accountType: number, values: number[]): Observable<RegisterResponse>{

        const requestBody = {
            Email: email,
            Password: password,
            CompanyName: companyName,
            FirstName: firstName,
            LastName: lastName,
            Zip: zipCode,
            AccountType: accountType,
            Values: values,
            ProfilePicture: Math.floor(Math.random() * 5)
        }
        console.log(requestBody)
        const data = this.httpClient.post<RegisterResponse>("https://localhost:7100/User/create", requestBody)
        return data
    }

    public login(email: string, password: string){
        const requestBody = {
            email: email,
            password: password
        }

        return this.httpClient.post<LoginResponse>("https://localhost:7095/User/Login", requestBody)
    }

    public updateAccount(requestBody: UpdateProfileRequest){
        return this.httpClient.post<UpdateResponse>("https://localhost:7095/User/Update", requestBody);
    }
}