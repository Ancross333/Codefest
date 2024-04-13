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

    public register(email: string, password: string, companyName: string | null, firstName: string, lastName: string, zipCode: number, accountType: number): Observable<RegisterResponse>{

        const requestBody = {
            email: email,
            password: password,
            companyName: companyName,
            firstName: firstName,
            lastName: lastName,
            zipCode: zipCode,
            accountType: accountType
        }

        return this.httpClient.post<RegisterResponse>("https://localhost:7095/User/Add", requestBody)
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