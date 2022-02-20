
class MaxHeapTree:
    def __init__(self):
        self.__heap = []

    @staticmethod
    def __left(i):
        return 2 * i + 1

    @staticmethod
    def __right(i):
        return 2 * i + 2

    @staticmethod
    def __parent(i):
        return (i - 1) // 2

    def get_heap(self):
        return self.__heap

    def display_heap(self):
        for i in self.__heap:
            print(i, " ", end="")
        print()

    def __max_heapify(self, array: list, index: int, length: int):
        largest = index
        left = self.__left(index)
        right = self.__right(index)

        if left <= length -1 and array[left] > array[index]:
            largest = left
        if right <= length - 1 and array[right] > array[largest]:
            largest = right

        if largest != index:
            array[index], array[largest] = array[largest], array[index]
            self.__max_heapify(array, largest, length)

    def build_max_heap(self, array: list):
        self.__heap = array
        length = len(self.__heap)
        for i in range(length):
            self.__max_heapify(self.__heap, i, length)

    def __build_max_heap(self, array: list):
        length = len(array)
        for i in range(length):
            self.__max_heapify(array, i, length)

    def add(self, num: int):
        self.__heap.append(num)
        pos = len(self.__heap) - 1
        while pos != 0:
            parent_pos = self.__parent(pos)
            if self.__heap[pos] > self.__heap[parent_pos]:
                self.__heap[pos], self.__heap[parent_pos] = self.__heap[parent_pos], self.__heap[pos]
                pos = parent_pos
            else:
                break

    def delete(self, index: int):
        length = len(self.__heap)
        self.__heap[index], self.__heap[0] = self.__heap[0], self.__heap[index]
        self.__heap[0], self.__heap[length - 1] = self.__heap[length - 1], self.__heap[0]

        self.__heap.remove(length - 1)

        self.__max_heapify(self.__heap, 0, length)

    def heap_sort(self, array: list):
        self.__build_max_heap(array)

        for i in range(len(array) - 1, 0, -1):
            array[i], array[0] = array[0], array[i]
            self.__max_heapify(array, 0, i)


if __name__ == '__main__':
    tree = MaxHeapTree()
    a = [16, 4, 10, 14, 7, 9, 3, 2, 8, 1]

    tree.build_max_heap(a)
    print(tree.get_heap())

    tree.heap_sort(a)
    print(a)
