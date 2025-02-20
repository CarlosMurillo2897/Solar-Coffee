import axios from "axios";
import { IProductInventory } from "@/types/ProductInventory";
import { IShipment } from "@/types/Shipment";

/**
 * InventoryService
 * Provides UI business logic associated with product inventory.
 */
export class InventoryService {
    API_URL = process.env.VUE_APP_API_URL;
    
    public async getInventory(): Promise<IProductInventory[]> {
        const result: any = await axios.get(`${this.API_URL}/inventory/`);
        return result.data;
    }
    
    public async updateInventoryQuantity(shipment: IShipment) {
      const result = await axios.patch(`${this.API_URL}/inventory/`, shipment)
      return result.data;
    }
}