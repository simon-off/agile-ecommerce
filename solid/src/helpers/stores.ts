import { Product } from "../types/product";
import { createLocalStore } from "./createLocalStore";

export const wishlistStore = createLocalStore<Product[]>("wishlist", []);
