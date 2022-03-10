class Node:

    Key = None
    Parent = None
    Left = None
    Right = None


class BinaryTry:
    Root: Node = None

    def in_order_tree_walk(self, node: Node):
        if node is not None:
            self.in_order_tree_walk(node.Left)
            print(node.Key, " ", end="")
            self.in_order_tree_walk(node.Right)

    def recursive_tree_search(self, node: Node, key: int) -> Node or None:
        if node is None or key == node.Key:
            return node

        if key < node.Key:
            return self.recursive_tree_search(node.Left, key)
        else:
            return self.recursive_tree_search(node.Right, key)

    @staticmethod
    def iterative_tree_search(node: Node, key: int) -> Node or None:
        current_node = node
        while current_node is not None and key != current_node.Key:
            if key < node.Key:
                current_node = current_node.Left
            else:
                current_node = current_node.Right
        return current_node

    @staticmethod
    def tree_min(node: Node) -> Node:
        current_node = node
        while current_node.Left is not None:
            current_node = current_node.Left
        return current_node

    @staticmethod
    def tree_max(node: Node) -> Node:
        current_node = node
        while current_node.Right is not None:
            current_node = current_node.Right
        return current_node

    def tree_insert(self, node: Node):
        y = None
        x = self.Root

        while x is not None:
            y = x

            if node.Key < x.Key:
                x = x.Left
            else:
                x = x.Right

        node.Parent = y

        if y is None:
            self.Root = node
        elif node.Key < y.Key:
            y.Left = node
        else:
            y.Right = node

    def transplant(self, u: Node, v: Node):
        if u.Parent is None:
            self.Root = v
        elif u == u.Parent.Left:
            u.Parent.Left = v
        else:
            u.Parent.Right = v

        if v is not None:
            v.Parent = u.Parent

    def tree_delete(self, node: Node):
        if node.Left is None:
            self.transplant(node, node.Left)
        elif node.Right is None:
            self.transplant(node, node.Right)
        else:
            successor = BinaryTry.tree_min(node.Right)
            if successor.Parent is not node:
                self.transplant(successor, successor.Right)
                successor.Right = node.Right
                successor.Right.Parent = successor
            self.transplant(node, successor)
            successor.Left = node.Left
            successor.Left.Parent = successor


if __name__ == '__main__':
    tree = BinaryTry()
    three = Node()
    eight = Node()

    for i in range(10):
        node = Node()
        if i == 3:
            three.Key = i
            tree.tree_insert(three)
        elif i == 8:
            eight.Key = i
            tree.tree_insert(eight)
        else:
            node.Key = i
            tree.tree_insert(node)

    tree.in_order_tree_walk(tree.Root)
    tree.tree_delete(three)
    print()
    tree.in_order_tree_walk(tree.Root)
