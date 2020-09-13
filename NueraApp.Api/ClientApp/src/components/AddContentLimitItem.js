import React, { Component } from 'react';


export class AddContentLimitItem extends Component {
    constructor(props) {
        super(props);
        this.state = {
        }
        this.handleToUpdate = this.props.handleToUpdate;
        this.onAdd = this.onAdd.bind(this);
        this.sayHello = this.sayHello.bind(this);
    }

    async onAdd() {
        //alert("onAdd");
        let headers = {
            "Content-Type": "application/json"
        }

        let data = {
            "name": "Item4h",
            "value": 470,
            "contentLimitCategoryId": 4
        }

        await fetch('ContentLimit/Items', {
            method: 'POST',
            headers: headers,
            body: JSON.stringify(data)
        });
        this.handleToUpdate();
    }

    sayHello() {
        alert('Hello!');
        this.handleToUpdate();
    }

    render() {
        
        return (
            <div>
                <input type="text" id="itemName" name="itemName" placeholder="Item Name" />
                <input type="number" id="itemValue" name="itemValue" step="10" placeholder="Item Value" />
                <select id="category" name="category">
                    <option value="1">Clothing</option>
                    <option value="2">Electronics</option>
                    <option value="3">Kitchen</option>
                    <option value="4">Miscellaneous</option>
                </select>
                <button onClick={this.onAdd}>Add</button>
            </div>
            
        );
    }
}