import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SendMessageResponse } from '../common/api-responses';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageService {

  constructor(private httpClient: HttpClient) { }

  public sendMessage(senderId: number, receiverId: number, createdAt: Date, content: string): Observable<SendMessageResponse>{
    const requestBody = {
      SenderId: senderId,
      ReceiverId: receiverId,
      CreatedAt: createdAt,
      Content: content
    }
    console.log(requestBody)
    return this.httpClient.post<SendMessageResponse>("https://localhost:7100/Messages/add", requestBody)
  }
}
