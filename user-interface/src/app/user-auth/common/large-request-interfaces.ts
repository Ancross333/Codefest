export interface UpdateProfileRequest {
    email: string;
    currentPassword: string;
    newPassword: string;
    firstName: string;
    lastName: string;
    zip: number;
}