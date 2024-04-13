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

export enum Values {
    Healthcare,
    Education,
    Environment,
    AnimalWelfare,
    ArtsAndCulture,
    DisasterRelief,
    HumanRights,
    Technology,
    SportsAndRecreation,
    CommunityDevelopment
}

export const CATEGORY_NAMES: string[] = Object.keys(Values).filter(key => isNaN(Number(key)));

export const getCategoryName = (index: number): string => {
    if (index < 0 || index >= CATEGORY_NAMES.length) {
        throw new Error("Index out of bounds");
    }
    return CATEGORY_NAMES[index];
}

export const getIndexByCategoryName = (categoryName: string): number => {
    const index = CATEGORY_NAMES.indexOf(categoryName);
    if (index === -1) {
        throw new Error("Category not found");
    }
    return index;
}
