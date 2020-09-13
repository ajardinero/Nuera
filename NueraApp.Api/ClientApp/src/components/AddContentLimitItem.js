import React, { Component } from 'react';


export class AddContentLimitItem extends Component {
    constructor(props) {
        super(props);
        this.state = {
        }
        this.notifyParent = this.props.updateNotification;
        this.onAdd = this.onAdd.bind(this);
    }

    async onAdd() {
        let selectedCategoryId = +document.getElementById("category").value;

        let headers = {
            "Content-Type": "application/json"
        }

        let data = {
            "name": document.getElementById("itemName").value,
            "value": +document.getElementById("itemValue").value,
            "contentLimitCategoryId": selectedCategoryId
        }

        await fetch('ContentLimit/Items', {
            method: 'POST',
            headers: headers,
            body: JSON.stringify(data)
        });
        this.notifyParent(selectedCategoryId);
    }

    render() {
        
        return (
            <div>
                <input class="item-name" type="text" id="itemName" name="itemName" placeholder="Item Name" />
                <input class="item-name" type="number" id="itemValue" name="itemValue" step="10" placeholder="Item Value" />
                <select id="category" name="category">
                    <option value="1">Clothing</option>
                    <option value="2">Electronics</option>
                    <option value="3">Kitchen</option>
                    <option value="4">Miscellaneous</option>
                </select>
                <button class="add" onClick={this.onAdd}>Add</button>
            </div>
            
        );
    }
}