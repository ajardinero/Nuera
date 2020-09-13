import React, { Component } from 'react';
import './custom.css'
import trash from '../img/trash.jpg';

export class ContentLimitItems extends Component {
    constructor(props) {
        super(props);
        this.state = {
            items: []
        }
        this.notifyParent = this.props.updateNotification;
        this.onDelete = this.onDelete.bind(this);
    }

    static getDerivedStateFromProps(nextProps, prevState) {
        return {
            items: nextProps.itemsDictionary[nextProps.categoryId]
        };
    }

    async onDelete(itemId) {
        await fetch('ContentLimit/Items/' + itemId, {
            method: 'DELETE'
        });
        this.notifyParent(this.props.categoryId);
    }

    render() {
        if (this.state.items === undefined) {
            return (<div />);
        }

        return (
            <div>
                {
                    this.state.items.map((item, itemIndex) => {
                        return(
                            <div>
                                <div class="item-name"> {item.name} </div>
                                <div class="item-value">{'\u0024'}{item.value} </div>
                                <div class="item-delete"><input class="delete" type="image" height="20" width="20" src={trash} onClick={() => this.onDelete(item.id)}/></div>
                            </div>
                        )
                    })
                }
            </div>
            );
    }
}