export const PriceSortType = {
  DEFAULT: "",
  LOWER_FIRST: "asc",
  HIGHER_FIRST: "desc",
} as const;

export type PriceSortType = (typeof PriceSortType)[keyof typeof PriceSortType];
