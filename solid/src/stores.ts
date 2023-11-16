import { Product } from "./types/product";
import { createLocalStore } from "./helpers/createLocalStore";

export const wishlistStore = createLocalStore<Product[]>("wishlist", []);
