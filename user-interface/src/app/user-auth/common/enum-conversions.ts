export const ZIP_CODES: string[] = [
    "99201",
    "99202",
    "99203",
    "99204",
    "99205",
    "99206",
    "99207",
    "99208",
    "99212",
    "99216",
    "99217",
    "99218",
    "99223",
    "99224"
];


export const getZipCode = (index: number) => {
    if (index < 0 || index >= ZIP_CODES.length) {
        throw new Error("Index out of bounds");
    }

    return ZIP_CODES[index];
}

export const getIndexByZipCode = (zipCode: string): number => {
    const index = ZIP_CODES.indexOf(zipCode);
    if (index === -1) {
        throw new Error("ZIP code not found");
    }
    return index;
};
