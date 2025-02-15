import axios from 'axios';

/**
 * InventoryService
 * Provides UI business logic associated with product inventory.
 */
export class InventoryService {
    API_URL = process.env.VUE_APP_API_URL;

    public async getInventory(): Promise<any> {
        console.log('get inv:', this.API_URL);
        
        let result: any = await axios.get(`${this.API_URL}/inventory/`);
    }
}