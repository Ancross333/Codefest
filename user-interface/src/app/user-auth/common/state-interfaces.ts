export interface User {
    id: number;
    email: string;
    companyName: string | null;
    firstName: string;
    lastName: string;
    zipCode: number;
    accountType: number; 
 }
 
 export interface Post {
     posterId: number;
     title: string;
     createdAt: Date;
     caption: string;
 }
 
 export interface Comment {
     commenterId: number;
     postId: number;
     createdAt: Date;
     content: string;
 }
 
 export interface Message {
     id: number;
     senderId: number;
     receiverId: number;
     createdAt: Date;
     content: string;
 }
 
 export interface Conversation{
     otherUserId: number;
     profilePicture: number;
     firstName: string;
     lastName: string;
 }